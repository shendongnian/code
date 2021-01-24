        static void Main(string[] args)
        {
            Console.WriteLine("Filter NAME:");
            var filterName = Console.ReadLine();
            Console.WriteLine("Filter VALUE:");
            var filterValue = Console.ReadLine();
            var program = new Program();
            var results = program.GetScbOptionsByFilter(filterName, filterValue);
            Console.WriteLine($"Total results: {results.Count()}");
            Console.ReadKey();
        }
