class Program
    {
        static void Main(string[] args)
        {
            int[] randNumber = new int[5];
            Random rand = new Random();
            Console.WriteLine("The random numbers are: ");
            for (int i = 0; i < 5; i++)
            {
                for (int h = 0; h < randNumber.Length; h++)
                {
                    randNumber[h] = rand.Next(1, 20);
                }
                randNumber = randNumber.OrderByDescending(x => x).ToArray();
                Console.WriteLine(string.Join(", ", randNumber));
            }
        }
    }
