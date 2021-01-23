    class Program
    {
        static void Main(string[] args)
        {
            var sorted = new List<int>();
            var frequencies = new Dictionary<int, int>();
            
            //Get a bunch of random numbers
            var numbers = GetSomeRandomNumbers(100);
            //Sort the numbers asscenting
            foreach (var number in numbers.OrderBy(i => i))
            {
                //This will add the numbers in the expected order
                sorted.Add(number);
                //Frequencies is just a lookup table of number -> frequency
                if (frequencies.ContainsKey(number))
                    frequencies[number]++;
                else
                    frequencies.Add(number, 1);
            }
            Console.WriteLine("--SORTED--");
            sorted.ForEach(number => Console.WriteLine(number));
            Console.WriteLine("--FREQUENCIES--");
            //Dump all of the frequencies as a quick test
            frequencies.ToList().ForEach(pair => Console.WriteLine(string.Format("{0} occurrences of {1}", pair.Value, pair.Key)));
            
            //Wiat
            Console.ReadLine();
        }
        private static List<int> GetSomeRandomNumbers(int count)
        {
            var random = new Random();
            var result = new List<int>();
            for (int i = 0; i < count; i++)
                result.Add(random.Next(0, 100));
            return result;
        }
    }
