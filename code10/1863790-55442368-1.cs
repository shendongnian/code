     private static bool ContainsValue(Dictionary<string, List<string>> dictionary)
            {
                foreach (var key in dictionary.Keys)
                {
                    if (dictionary[key].Contains("pop"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
