    string[] lines = System.IO.File.ReadAllLines(@"C:\TextFile1.txt");
            var dictionary = new Dictionary<int, List<string>>();
            foreach (var line in lines)
            {
                string[] vals = line.Split("-");
                var result = Convert.ToInt32(vals[0].Trim());
                var name = vals[1].Trim();
                if (!dictionary.ContainsKey(Convert.ToInt32(vals[0].Trim())))
                {
                    dictionary.Add(result, new List<string> { new string(name) });
                }
                else
                {
                    var duplicate = dictionary.GetValueOrDefault(result);
                    duplicate.Add(name);
                }
                
            }
            var orderedList = dictionary.OrderBy(r => r.Key);
