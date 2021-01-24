            var resultDictionary = new Dictionary<string, List<int>>();
            var filteredDictonary = new Dictionary<string, int[]>();
            var arrayOfDictionaries = new Dictionary<string, int>[]
            {
                new Dictionary<string, int> { { "a", 7 },{ "b",5},{ "c", 10 } },
                new Dictionary<string, int> { { "a", 8 },{ "b",6},{ "c", 10 } },
                new Dictionary<string, int> { { "a", 7 },{ "b",7},{ "c", 10 } },
            };
            for (var j = 0; j < arrayOfDictionaries.Length; j++)
            {
                foreach (var i in arrayOfDictionaries[j])
                {
                    var uniqueKey = i.Key + i.Value.ToString();
                    if (resultDictionary.ContainsKey(uniqueKey))
                    {
                        resultDictionary[uniqueKey].Add(j);
                    }
                    else
                    {
                        resultDictionary.Add(uniqueKey, new List<int> { j });
                    }
                }
            }
            filteredDictonary = resultDictionary.Where(a => a.Value.Count() > 1).Select(a => a).ToDictionary(kv => kv.Key.Substring(0,1), kv => kv.Value.ToArray());
