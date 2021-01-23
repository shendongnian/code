    using System;
    
    class TestIt 
    {
        static void Function(ref string input)
        {
            input = "modified";
        }
    
        static void Function2(int[] val) // don't need ref for reference type
        {
            val = new int[10];  // Change: create and assign a new array to the parameter variable
            val[0] = 100;
        }
        static void Main()
        {
            string input = "original";
            Console.WriteLine(input);
            Function(ref input);      // need ref to modify the input
            Console.WriteLine(input);
    
            int[] val = new int[10];
            val[0] = 1;
            Function2(val);
            Console.WriteLine(val[0]); // This line still prints 1, not 100!
        }
    }
