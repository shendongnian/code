    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    class Base{}    
    class Foo:Base{}
    
    class Test
    {
        static bool Bar(Type t)
        {
            return typeof(IEnumerable<Base>).IsAssignableFrom(t);
        }
    
        static void Main()
        {
            Console.WriteLine(Bar(typeof(IEnumerable<Foo>)));
            Console.WriteLine(Bar(typeof(IEnumerable<Base>)));
            Console.WriteLine(Bar(typeof(string)));
            Console.WriteLine(Bar(typeof(Foo)));
        }
    }
