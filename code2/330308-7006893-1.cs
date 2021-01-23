        public class TestClass
        {
            public InnerClass this[string indexParameter]
            {
                get
                {
                    return new InnerClass { Value = indexParameter.ToUpper() };
                }
            }
        }
        public class InnerClass
        {
            public string Value { get; set; }
        }
