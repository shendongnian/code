    static void Main()
    {
        var words = new List<string>() { "E31f", "E3X", "E3", "M5", "BR30O", "BR10E", "BRC", "BR3", "BR3R", "WT2O", "WT3E", "T1A", "T3O", "TO2", "TO3E", "EL6", "EL3", "E", "T3", "BC1", "BC3" };
        var keywords = new List<string>() { "E", "M", "BR", "WT", "T", "TO", "EL", "BC" };
        // We need to be a little tactful here. Your keyword list contains both E and EL, so if we simply do a `string.Contains()`, we want to make sure that EL is considered before E.
        // So we sort by length first, and then by ascending order.
        // So the sorted keywords look like this: BC,BR,EL,TO,WT,E,M,T
        var sortedKeywords = keywords.OrderByDescending(x => x.Length).ThenBy(x => x);
        foreach (var word in words)
        {
            var extract = string.Empty;
            // We see if the selected word in the list starts with any of the keys in the sorted list.
            // Since we started it, EL will be checked before E, TO will be checked before T, etc.
            var key = sortedKeywords.FirstOrDefault(word.StartsWith);
            if (!string.IsNullOrEmpty(key))
            {
                extract = key;
                // We set the extract = key. Now if key is the same as the word, we simply contiue the loop.
                if (word.Length > key.Length)
                {
                    // If there are more characters we check the next character.
                    var next = word.Skip(key.Length).Take(1).FirstOrDefault().ToString();
                    if (int.TryParse(next, out int num))
                    {
                        if (num == 3)
                        {
                            // If the next character is 3 and there are more characters
                            if (word.Length > key.Length + 1)
                            {
                                // Check the next of next
                                var nextnext = word.Skip(key.Length + 1).Take(1).FirstOrDefault().ToString();
                                // If next of next is not a number, we append 3 to the ky
                                // Otherwise extract is the same as the key which we already set
                                if (!int.TryParse(nextnext, out num))
                                {
                                    extract = key + 3.ToString();
                                }
                            }
                            // If the next character is 3 and its the last one, we append 3 to the key
                            else
                            {
                                extract = key + 3.ToString();
                            }
                        }
                    }
                }
            }
            Console.WriteLine("{0} --> \t{1}", word, extract);
        }
        Console.ReadLine();
    }
