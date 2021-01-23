    class Example
    {
        static void Main()
        {
            string s = "hello, world";
            // Here we are passing a copy of the reference
            // stored in "s" to "Print"
            Print(s);
        }
        static void Print(string str)
        {
            // By default, "str" will be assigned the copy of the 
            // reference passed to this method.
            Console.WriteLine(s);
        }
    }
