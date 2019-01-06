using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Foods;


namespace FoodsTest
{
    [TestFixture]
    public class FoodsTests
    {
              
        List<Program.Food> foods_list;
        Program p = new Program();
        [Test]
        public void AllFoodsData()
        {           
            Task<List<Program.Food>> foods = p.getAllFoods();
            foods_list = foods.Result;
            foreach (Program.Food food in foods_list)
            {
                Assert.IsNotNull(food.id);
                Assert.IsNotNull(food.name);
                Assert.IsNotNull(food.description);
                Assert.IsNotNull(food.carbs);
                Assert.IsNotNull(food.proteins);
                Assert.IsNotNull(food.fats);
            }
        }

        [Test]
        public void GetTotalCarbContent()
        {
            Task<List<Program.Food>> foods = p.getAllFoods();
            foods_list = foods.Result;
            int total_carbs = p.calculateCarbs(foods_list);
            Assert.AreEqual(63, total_carbs);

        }

        [Test]
        public void GetTotalProteinContent()
        {
            Task<List<Program.Food>> foods = p.getAllFoods();
            foods_list = foods.Result;
            int total_proteins = p.calculateProteins(foods_list);
            Assert.AreEqual(63, total_proteins);
        }

    }
}
