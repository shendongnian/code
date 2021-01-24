            class ListBuilder
        {
            Dictionary<int, List<string>> options = new Dictionary<int, List<string>>();
            public ListBuilder()
            {
                options.Add(1, new List<string>() { "A", "B", "C" });
                options.Add(2, new List<string>() { "X", "Y"});
                //you can initialize multiple lists here
            }
            public List<string> AllCombos
            {
                get
                {
                    return GetAllPossibleCombos(options);
                }
            }
            List<string> GetAllPossibleCombos(IEnumerable<KeyValuePair<int, List<string>>> remainingOptions)
            {
                if (remainingOptions.Count() == 1)
                {
                    return remainingOptions.First().Value;
                }
                else
                {
                    var current = remainingOptions.First();
                    List<string> outputs = new List<string>();
                    List<string> combos = GetAllPossibleCombos(remainingOptions.Where(option => option.Key != option.Key));
                    foreach (var tagPart in current.Value)
                    {
                        foreach (var combo in combos)
                        {
                            outputs.Add(tagPart + combo);
                        }
                    }
                    return outputs;
                }
            }
        }
