    using System;
    namespace FooBar 
    {
        class Program 
        {
            static void Main(string[] args) 
            {
                new Foo();
            }
            class Foo 
            {
                public string Bar {get;}{set;}
                
                public Foo() 
                {
                    Bar = null;
                    if (Bar != null) 
                    {
                        throw new Exception("_Bar is not null.");
                    }
                }
            }
        }
    }
