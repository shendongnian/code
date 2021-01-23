    using System;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            int[] current = new[] { 1, 3, 9, 11, 5 };
            // Check all odd or all even    
            if (current.Select(x => x % 2).Distinct().Skip(1).Any())
            {
                Console.WriteLine("No solution!");
                return;
            }
            
            while (current != null)
            {
                Console.WriteLine(string.Join(" ", current));
                current = Transform(current);
            }
        }
        
        static int[] Transform(int[] input)
        {
            // We could do the "mean" calculation just once,
            // but it doesn't really matter for the sake of
            // demonstration
            int max = input.Max();
            int min = input.Min();
            if (max == min)
            {
                // Done
                return null;
            }
            
            int mean = (max + min) / 2;
            return input.Select(x => x > mean ? x - 1 : x + 1)
                        .ToArray();
        }
    }
