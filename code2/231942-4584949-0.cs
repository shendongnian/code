    Dictionary<string, int> dictionary = GetDictionary();
    
    if (dictionary.ContainsKey("MyKey"))
    {
        dictionary["MyKey"] += 5;
    }
    else
    {
        dictionary.Add("MyKey", 5);
    }
