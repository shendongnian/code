    using System;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            int[] values = new int[] { 1, 2, 4, 6, 9 };
            int startValue = 4;
            int[] orderedValues = values
                .OrderBy(v => v < startValue) // Note reversed comparison
                .ThenBy(v => v)               // Order by value within each segment
                .ToArray();
            Console.WriteLine(string.Join(", ", orderedValues));
        }
    }
