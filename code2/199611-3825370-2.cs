    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static IEnumerable<string> Foo()
        {
            Console.WriteLine("I won't get printed");
            yield break;
        }
        
        static void Main()
        {
            Foo();
        }
    }
