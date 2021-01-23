    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 2, 3, 4, 5, 6, 1, 2, 3, 1, 1, 1, 7, 12, 451, 13, 
                46, 1, 1, 3, 2, 3, 4, 5, 3, 2, 4, 4, 5, 6, 6, 8, 9, 0};
            var numberGroups =
                (from n in nums
                group n by n into g
                orderby g.Count() descending
                select new { Number = g.Key, Count = g.Count() }
                ).Take(10);
            Console.ReadLine();
        }
    }
