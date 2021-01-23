    class Test
    {
        static void Foo(ref int p)
        {
            p = p + 1;             // Increment p by one.
            Console.WriteLine(p);  // Write p to screen.
        } 
        static void Main()
        {
            int x = 8;            
            Foo(ref x);           // Make a copy of x.
            Console.WriteLine(x); // x is now 9.
        }
    }
