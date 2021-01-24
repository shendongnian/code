    static void Main(string[] args)
        {
            var theList = Enumerable.Range(0, 10).Select(i => new Tuple<int, int>(i, i + 1));
            Console.WriteLine(CheckDuplicate(theList, new { Item1 = 5, Item2 = 6 }, "Item1", "Item2"));
            Console.ReadKey();
        }
