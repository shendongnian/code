    class Program
    {
        static void Main(string[] args, int answer)
        {
            //Local Variables
            int i;
            int total = 0;
            //Initialize Console
            Console.WriteLine("Enter a number to begin");
            string input = Console.ReadLine();
            //Create integer from string input
            int number = int.Parse(input);
            //For Loop Looking for Multiples
            for (i = 0; i < number; i++)
            {
                if (i % 4 == 0 || i % 6 == 0)
                {                    
                    total += i;
                }
                Console.WriteLine(total);
            }
        }
    }
