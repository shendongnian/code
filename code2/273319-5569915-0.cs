    using System;
    
    class Test
    {
        static void Main()
        {
            Foo("hello", new object());
        }
    
        static void Foo<T>(T first, T second)
        {
        }
    }
