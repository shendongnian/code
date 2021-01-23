    using System;
    using System.Globalization;
    using System.Linq;
    
    public class Test
    {
        static void Main()
        {
            string eventIds = "1,2,3";
            int[] array =
                eventIds.Split(',')
                        .Select(x => int.Parse(x, CultureInfo.InvariantCulture))
                        .ToArray();
            foreach (int id in array)
            {
                Console.WriteLine(id);
            }
        }
    }
