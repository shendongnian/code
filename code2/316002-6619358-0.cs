        static void Main(string[] args)
        {
            string infix = "( 5 + 2 ) * 3 + 4";
            string[] results = infix.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var result in results)
                Console.WriteLine(result);
            Console.ReadLine();
        }
