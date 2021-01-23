    private Dictionary<string, string> ParseKeyValues(string input)
            {
                Dictionary<string, string> items = new Dictionary<string, string>();
    
                string[] parts = input.Split(':');
    
                string key = parts[0];
                string value;
    
                int currentIndex = 1;
    
                while (currentIndex < parts.Length-1)
                {
                    int indexOfLastSpace=parts[currentIndex].LastIndexOf(' ');
                    value = parts[currentIndex].Substring(0, indexOfLastSpace);
                    items.Add(key, value);
                    key = parts[currentIndex].Substring(indexOfLastSpace + 1);
                    currentIndex++;
                }
                value = parts[parts.Length - 1].Substring(0,parts[parts.Length - 1].Length-1);
                
    
                items.Add(key, parts[parts.Length-1]);
    
                return items;
    
            }
