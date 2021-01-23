                var oldList = new List<String>() {"AAA", "BBB", "CCC"};
                var newList = new List<String>() {"BBB", "CCC", "DDD"};
    
                var diffDictionary = new Dictionary<string, string>();
    
                foreach (var oldEntry in oldList)
                {
                    diffDictionary.Add(oldEntry, "Remove");
                }
    
                foreach (var newEntry in newList)
                {
                    if (diffDictionary.ContainsKey(newEntry))
                    {
                        diffDictionary[newEntry] = "Keep";
                    }
                    else
                    {
                        diffDictionary.Add(newEntry, "Add");
                    }
                }
    
                foreach (var dDico in diffDictionary)
                {
                    Console.WriteLine(string.Concat("Key: ", dDico.Key, " Value: ", dDico.Value));
                }
