    using System;
    
    class test
    {
        static int Main(string[] argsin)
        { 
    
            for (int i = 0; i < argsin.Length; i++ )
                Console.WriteLine("Argument: {0}", argsin[i]);
            Console.ReadLine();
            return -1;
        }
    }
