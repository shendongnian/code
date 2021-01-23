        public class ExampleClass
        {
            //create properties like this...
            private readonly int _exampleProperty;
            public int ExampleProperty { get { return _exampleProperty; } }
            //Private constructor, prohibiting construction outside of this class
            private ExampleClass(ExampleClassParams parameters)
            {                
                _exampleProperty = parameters.ExampleProperty;
                //and so on... 
            }
            //The object returned from here will be immutable
            public ExampleClass GetFromDatabase(DBConnection conn, int id)
            {
                //do database stuff here (ommitted from example)
                ExampleClassParams parameters = new ExampleClassParams()
                {
                    ExampleProperty = 1,
                    ExampleProperty2 = 2
                };
                //Danger here as parameters object is mutable
                return new ExampleClass(parameters);    
                //Danger is now over ;)
            }
                        
            //Private struct representing the parameters, nested within class that uses it.
            //This is mutable, but the fact that it is private means that all potential 
            //"damage" is limited to this class only.
            private struct ExampleClassParams
            {
                public int ExampleProperty { get; set; }
                public int AnotherExampleProperty { get; set; }
                public int ExampleProperty2 { get; set; }
                public int AnotherExampleProperty2 { get; set; }
                public int ExampleProperty3 { get; set; }
                public int AnotherExampleProperty3 { get; set; }
                public int ExampleProperty4 { get; set; }
                public int AnotherExampleProperty4 { get; set; } 
            }
        }
