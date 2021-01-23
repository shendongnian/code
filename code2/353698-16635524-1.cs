    using System.Collections.Generic;
    using NUnit.Framework;
    
    namespace SerializeRandom
    {
        public class RandomGeneratorTest
        {
            [Test]
            public void TestDictionary1()
            {
                var randomGenerator = RandomGenerator.Load();
    
                var randomResult1 = new List<int>();
                for (int i = 0; i < 10; i++)
                {
                    randomResult1.Add(randomGenerator.GetNext());
                }
                RandomGenerator.Save(randomGenerator);
    
                randomGenerator = RandomGenerator.Load();
                var randomResult2 = new List<int>();
                for (int i = 0; i < 10; i++)
                {
                    randomResult2.Add(randomGenerator.GetNext());
                }
    
                CollectionAssert.AreNotEqual(randomResult1, randomResult2);
    
            }
    
        }
    }
