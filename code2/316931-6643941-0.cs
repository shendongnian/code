        using System;
        using System.Collections.Generic;
        using Microsoft.VisualStudio.TestTools.UnitTesting;
        
    namespace ClassLibrary3
    {
        [TestClass]
        public class Class1
        {
            [TestMethod]
            public void test()
            {
                var fruits = new List<Fruit> {new Fruit(), new Fruit(), new Fruit()};
    
                var lists = AddFruits(fruits);
                Assert.IsTrue(fruits.Count == 3);
    
            }
    
            public List<Apple> AddFruits(IEnumerable<Fruit> fruitsToAdd)
            {
                var apples = new List<Apple>
                                 {
                                     new Apple(),
                                     new Apple()
                                 };
    
                foreach (var apple in apples)
                {
                    apple.AddFruits(fruitsToAdd);
                }
                return apples;
            }
        }
    
        public class Fruit 
        {
        }
       
        public class Apple
        {
            private ICollection<Fruit> _fruits = new List<Fruit>();
    
            public void AddFruits(IEnumerable<Fruit> fruits)
            {
                if (fruits == null) throw new ArgumentNullException("fruits");
                foreach (var fruit in fruits)
                {
                    _fruits.Add(fruit);
                }
            }
        }
    }
