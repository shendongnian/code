    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main(string[] args)
        {
            int[] input = {10,21,45,22,7,2,67,19,13,45,12,
                    11,18,16,17,100,201,20,101};
            
            Dictionary<int, int> starts = new Dictionary<int, int>();
            Dictionary<int, int> ends = new Dictionary<int, int>();
            
            foreach (var value in input)
            {
                int startLength;
                int endLength;
                bool extendsStart = starts.TryGetValue(value + 1,
                                                       out startLength);
                bool extendsEnd = ends.TryGetValue(value - 1,
                                                   out endLength);
                
                // Stitch together two sequences
                if (extendsStart && extendsEnd)
                {
                    ends.Remove(value + 1);
                    starts.Remove(value - 1);
                    int start = value - endLength;
                    int newLength = startLength + endLength + 1;
                    starts[start] = newLength;
                    ends[start + newLength - 1] = newLength;
                }
                // Value just comes before an existing sequence
                else if (extendsStart)
                {
                    int newLength = startLength + 1;
                    starts[value] = newLength;
                    ends[value + newLength - 1] = newLength;
                    starts.Remove(value + 1);
                }
                else if (extendsEnd)
                {
                    int newLength = startLength + 1;
                    starts[value - newLength + 1] = newLength;
                    ends[value] = newLength;
                    ends.Remove(value - 1);
                }
                else
                {
                    starts[value] = 1;
                    ends[value] = 1;
                }
            }
    
            // Just for diagnostics - could actually pick the longest
            // in O(n)
            foreach (var sequence in starts)
            {
                Console.WriteLine("Start: {0}; Length: {1}",
                                  sequence.Key, sequence.Value);
            }
        }
    }
