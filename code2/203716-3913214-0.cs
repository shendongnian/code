    using System;
    using System.Collections;
    
    class Test
    {
        static void Main(string[] args)
        {
            foreach (string x in Foo())
            {
                Console.WriteLine (x);
            }
        }
        
        static IEnumerable Foo()
        {
            yield return "Hello";
            yield return "there";
        }
    }
