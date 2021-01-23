    static void Main(string[] args)
        {
            Regex regex = new Regex(@".*");
            MatchCollection matches = regex.Matches("  227.905  ");
            foreach (var match in matches)
            {
                Console.WriteLine("[{0}]", match);
            }
            Console.ReadKey();
        }
        
