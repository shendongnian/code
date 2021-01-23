        static void Main(string[] args)
        {
            int test = 1;
            resetTest(ref test);
    
            Console.Write(test); // Should be 0
        }
    
        static void resetTest(ref int test)
        {
            test = 0;
        }
