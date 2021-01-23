    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Test
    {
        static void Main(string[] args)
        {
            int[] input = {10,21,45,22,7,2,67,19,13,45,12,
                    11,18,16,17,100,201,20,101};
    
            HashSet<int> values = new HashSet<int>(input);
            
            int bestLength = 0;
            int bestStart = 0;
            // Can't use foreach as we're modifying it in-place
            while (values.Count > 0)
            {
                int value = values.First();
                values.Remove(value);
                int start = value;
                while (values.Remove(start - 1))
                {
                    start--;
                }
                int end = value;
                while (values.Remove(end + 1))
                {
                    end++;
                }
                
                int length = end - start + 1;
                if (length > bestLength)
                {
                    bestLength = length;
                    bestStart = start;
                }
            }
            Console.WriteLine("Best sequence starts at {0}; length {1}",
                              bestStart, bestLength);
        }
    }
