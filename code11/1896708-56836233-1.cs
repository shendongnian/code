        public class TestClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
            private TestClass()
            {
            }
            public TestClass(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public static Expression<Func<LdbRecord, TestClass>> ConvertPoco
            {
                get
                {
                    return p => new TestClass() { Id = p.RecordId, Name = p.RecordName };
                }
            }
        }
