    class Program
    {
        static void Main(string[] args)
        {
            var data = new[]
            {
                12, 12, 12, 12, 12, 17, 
                17, 17, 17,12, 12, 12, 12, 
                12, 17, 17, 17, 17,17, 17, 
                17, 12, 12, 12, 12, 12
            };
    
            var result = SpecialSum(data, 17).ToArray();
            Console.WriteLine(string.Join(",", result));
        }
    
        private static IEnumerable<int> SpecialSum(int[] data, int target)
        {
            var group = 0;
            var number = new int?();
            return data.GroupBy(x =>
            {
                number = number ?? x;
                if (x != number)
                {
                    number = x;
                    group++;
                }
                return (group, number);
            }).Where(x => x.Key.number == target)
              .Select(x => x.Sum());
        }
    }
