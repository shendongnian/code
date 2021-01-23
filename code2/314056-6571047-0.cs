           static void Main(string[] args)
        {
            Dictionary<string, string[]> d = new Dictionary<string, string[]>();
            d.Add("cat", new string[] { "2", "2" });
            d.Add("dog", new string[] { "10", "A" });
            d.Add("llama", new string[] { "A", "B" });
            d.Add("iguana", new string[] { "-2", "-3" });
            // Not clear if you care about the order - this will insure that the names are in alphabetical order. 
            // The order of items in a dictionary are not guarenteed to be the same as the order they were added.
            var names = d.Keys.OrderBy(l => l).ToList();
            // Not clear if you know the number of items that will be in the list in advance - if not, find the max size 
            int maxSize = d.Values.Max(a => a != null ? a.Length : 0);
            Console.WriteLine(String.Join(", ", names));
            for (int i = 0; i < maxSize; i++)
            {
                foreach (string name in names)
                {
                    string[] value = d[name];
                    if ((value != null) && (i < value.Length))
                    {
                        Console.Write(value[i]);
                    }
                    if (name != names.Last())
                    {
                        Console.Write(",");
                    }
                }
                Console.WriteLine();
            }
        }
