    [TestFixture]
    public class SOFixture
    
        public class SubChild
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Value { get; set; }
        }
        public class Child
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public List<SubChild> List { get; set; }
        }
        public class Parent
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public List<Child> List { get; set; }
        }
    
        [Test]
        public void SOTest()
        {
    
            var ListParent = new List<Parent>();
            ListParent.Add(
                new Parent()
                {
                    ID = 1,
                    Name = "1",
                    List = new List<Child>() { new Child () {ID = 1, Name = "1",
                        List = new List<SubChild>() { new SubChild() {ID = 1, Name = "1", Value = 2}}
                    }}
                });
    
            ListParent.Add(
                new Parent()
                {
                    ID = 2,
                    Name = "2",
                    List = new List<Child>() { new Child () {ID = 2, Name = "2",
                        List = new List<SubChild>() { new SubChild() {ID = 2, Name = "2", Value = 201}}
                    }}
                });
            Assert.AreEqual(2, ListParent.Count());
            Console.WriteLine(ListParent.Count());
    
            var FilteredParent = ListParent.Where(
                                    p => p.List.Any(
                                        c => c.List.Any(sc => sc.Value > 1 && sc.Value < 200)
                                    )
                                );
            Assert.AreEqual(1, FilteredParent.Count());
            Console.WriteLine(FilteredParent.Count());
    
            var FilteredParent2 = from lp in ListParent
                             where (
                                 from c in lp.List
                                 where (
                                    from sc in c.List
                                    where sc.Value > 1 && sc.Value < 200
                                    select sc
                                ).Any()
                                 select c
                            ).Any()
                             select lp;
            Assert.AreEqual(1, FilteredParent2.Count());
            Console.WriteLine(FilteredParent2.Count());
        }
    )
