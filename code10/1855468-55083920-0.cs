    class Program
    {
        static void Main(string[] args)
        {
            string[] array =
            {
                "king",
                "queen",
                "throne"
            };
            var result = array.SelectMany(element => element.ToCharArray())
                .Where(RemoveLetterTSpec)
                .Where(RemoveLetterESpec);
            foreach (char letter in result)
            {
                Console.WriteLine(letter);
            }
            Console.ReadLine();
        }
        private static bool RemoveLetterESpec(char arg)
        {
            return arg != 'e';
        }
        private static bool RemoveLetterTSpec(char arg)
        {
            return arg != 't';
        }
    }
