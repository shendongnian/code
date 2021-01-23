    var dictionary = new Dictionary<int, string>();
    
    int start, count;
    GetRange(out start, out count);
    string value = GetValue();
    
    foreach (int key in Enumerable.Range(start, count))
    {
        // Look, you're using the same string instance to assign
        // to each key... how could it be otherwise?
        dictionary[key] = value;
    }
