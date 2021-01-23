      private class TestClass
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        static void Main(string[] args)
        {
            var list = new List<TestClass> {
                new TestClass{ X=1,Y=2},
                new TestClass{ X=3,Y=4}
            };
            Console.WriteLine(JsonConvert.SerializeObject(list.ToDynamicList(i => new
            { X = "null value", Z = i.X == 1 ? 0 : 1 })));
        }
