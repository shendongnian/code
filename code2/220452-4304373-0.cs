        static void Main(string[] args)
        {
            int[] numbers = new int[]
            {
                1,2,3,4,5,6,7,8,9,0
            };
            var result = from n in numbers group n by n%2
                         into group_numbers
                         select new { short_group = group_numbers.Take(3) };
            
            foreach(var v in result)
            {
                foreach (var v1 in v.short_group)
                {
                    Console.WriteLine(v1.ToString());
                }
                Console.WriteLine();
            }
        }
