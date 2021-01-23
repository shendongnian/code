    static void Main(string[] args)
    {
        var result = new SortedDictionary<char, List<int>>();
        var lines = System.IO.File.ReadAllLines(@"input.txt");
        foreach (var line in lines)
        {
            var split = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var lineNumber = Int32.Parse(split[0].Substring(0,1));
            foreach (var letter in split.Skip(1))
            {
                var key = letter[0];
                if (!result.ContainsKey(key))
                {
                    result.Add(key, new List<int> { lineNumber });
                }
                else
                {
                    result[key].Add(lineNumber);
                }
            }
        }
        foreach (var item in result)
        {
            Console.WriteLine(String.Format("{0}: {1}", item.Key, String.Join(" ", item.Value)));
        }
        Console.ReadKey();
    }
