    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            var list = new List<int> { 1, 4, 5, 6, 9, 10 };
            
            
            /* This version fails with an InvalidOperationException
            foreach (int x in list)
            {
                if (x < 5)
                {
                    list.Add(100);
                }
                Console.WriteLine(x);
            }
             */
            
            // This version is okay
            for (int i = 0; i < list.Count; i++)
            {
                int x = list[i];
                if (x < 5)
                {
                    list.Add(100);
                }
                Console.WriteLine(x);            
            }
        }
    }
