    class Test
    {
        static void Foo(int p)
        {
            p = p + 1;             // Increment p by one.
            Console.WriteLine(p);  // Write p to screen.
        } 
        static void Main()
        {
            int x = 8;            
            Foo(x);               // Make a copy of x.
            Console.WriteLine(x); // x will still be 8.
        }
    }
