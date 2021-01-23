    using System;
    
    enum Foo { A, B, C };
    
    class Test
    {
        static void Main()
        {
            Foo x = Foo.B;
            int y = (int) x;
        }    
    }
