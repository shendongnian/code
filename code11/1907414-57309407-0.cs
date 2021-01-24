      static void Main(string[] args)
            {
                SortedDictionary<int, string> tuples = new SortedDictionary<int, string>();
                string[] stringsToSortByNumbers = { "test.1", "test.10", "test.2" };
    
                foreach (var item in stringsToSortByNumbers)
                {
                    int numeric = Convert.ToInt32(new String(item.Where(Char.IsDigit).ToArray()));
                    tuples.Add(numeric, item);
                }
    
                foreach (var item in tuples)
                {
                    Console.WriteLine(item.Value);
                }
    
                Console.ReadKey();
    
            }
