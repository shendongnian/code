    class SomeClass
        {
            private string _someCriteria;
    
            private SomeClass(string someCriteria)
            {
                _someCriteria = someCriteria;
            }
    
            public static SomeClass CreateInstance(string someCriteria)
            {
                if (someCriteria.Length > 2)
                {
                    return new SomeClass(someCriteria);
                }
                return null;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
    
                // returns null
                SomeClass someClass = SomeClass.CreateInstance("t");
    
                // returns object
                SomeClass someClass2 = SomeClass.CreateInstance("test");
            }
        }
