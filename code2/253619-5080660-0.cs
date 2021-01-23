    var something = new List<string>() { "One", "One", "Two", "Three" };
    
    var dictionary = new Dictionary<string, int>();
    
    something.ForEach(s =>
        {
            if (dictionary.ContainsKey(s))
            {
                dictionary[s]++;
            }
            else
            {
                dictionary[s] = 1;
            }
        });
