    class Program
    {
        static void Main()
        {
            foreach (var item in GetRegions("google_insights.txt"))
            {
                Console.WriteLine("Count = {0}, Name = {1}", item.Key, item.Value);
            }
        }
        private static Regex _regionRegex = new Regex(
            @"^(?<name>.+)\s(?<count>[0-9]+)$", 
            RegexOptions.Compiled
        );
    
        static IEnumerable<KeyValuePair<int, string>> GetRegions(string filename)
        {
            using (var file = File.OpenRead(filename))
            using (var reader = new StreamReader(file))
            {
                string line;
                bool yielding = false;
                while ((line = reader.ReadLine()) != null)
                {
                    if (yielding && string.IsNullOrWhiteSpace(line))
                    {
                        yield break;
                    }
    
                    if (yielding)
                    {
                        var match = _regionRegex.Match(line);
                        if (match.Success)
                        {
                            var count = int.Parse(match.Groups["count"].Value);
                            var name = match.Groups["name"].Value;
                            yield return new KeyValuePair<int, string>(count, name);
                        }
                    }
    
                    if (line.Contains("subregions"))
                    {
                        yielding = true;
                    }
                }
            }
    
        }
    }
