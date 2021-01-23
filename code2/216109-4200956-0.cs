    [TestClass]
    public class HierarchyTest
    {
        #region Ani's code
        class Entity
        {
            public Entity Parent { get; set; }
    
            public IEnumerable<Entity> Hierarchy
            {
                // note: buffers results
                get { return UpwardHierarchy.Reverse(); }
            }
    
            public int YieldCount = 0;//modified
            public IEnumerable<Entity> UpwardHierarchy
            {
                get
                {
                    // genuine lazy streaming
                    for (var entity = this; entity != null; entity = entity.Parent)
                    {
                        YieldCount++;//modified
                        yield return entity;
                    }
                }
            }
        }
        #endregion
    
    
        [TestMethod]
        public void TestMethod1()
        {
            /*
            Entity 1
            - Entity 1.2
              - Entity 1.2.2
                - Entity 1.2.2.2
             */
            var e1 = new Entity();
            var e12 = new Entity() { Parent = e1 };
            var e122 = new Entity() { Parent = e12 };
            var e1222 = new Entity() { Parent = e122 };
    
            var hierarchy = e1222.Hierarchy;
            Assert.AreEqual(0, e1222.YieldCount);//nothing was evaluated until now
            hierarchy.First();
            Assert.AreEqual(4, e1222.YieldCount);//the entire UpwardHierarchy has been yielded to get the first Hierarchy item
            hierarchy.First();
            Assert.AreEqual(8, e1222.YieldCount);//yielded all UpwardHierarchy  itens again to get the first Hierarchy item
    
            List<Entity> evaluatedHierarchy = e1222.Hierarchy.ToList();//calling ToList() produces a List<Entity> instance so UpwardHierarchy and Reverse() are evaluated only once
            Assert.AreEqual(12, e1222.YieldCount);//Yieldcount+=4 because of ToList()
            evaluatedHierarchy.First();
            Assert.AreEqual(12, e1222.YieldCount);//and now you can use evaluatedHierarchy as you wish without causing another UpwardHierarchy and Reverse() call.
            evaluatedHierarchy.First();
            Assert.AreEqual(12, e1222.YieldCount);
        }
    }
