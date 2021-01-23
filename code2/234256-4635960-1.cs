    **Foo.cs**
    
        using System;
        
        public class Foo
        {
            public static void Report()
            {
                Console.WriteLine("Foo.Report");
            }
        }
    
    **Test.cs**
    
        class Test
        {
            static void Main()
            {
                Foo.Report();
            }
        }
