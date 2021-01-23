        static void Main(string[] args)
        {
            HashSet<string> numbers = new HashSet<string>();
            for (int i = 0; i < 100; i++)
            {
                numbers.Add(GenerateRandomNumber(8));
            }
            Console.WriteLine(numbers.Count == 100);
            Console.ReadLine();
        }
        static Random random = new Random();
        static string GenerateRandomNumber(int count)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                int number = random.Next(10);
                builder.Append(number);
            }
            return builder.ToString();
        }
