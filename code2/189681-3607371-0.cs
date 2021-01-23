    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            int[,] matrix=new int[3,3]
                    {
                       {1,2,3},
                       {4,5,6},
                       {11,34,56}
                    };
            
            IEnumerable<int> values = matrix.Cast<int>()
                                            .Select(x => x * x);
            foreach (int x in values)
            {
                Console.WriteLine(x);
            }
        }
    }
