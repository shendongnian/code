    List<string> result = new List<string>();
    
    while (original.Length > 0)
    {
        result.Add(new String(original.Take(2).ToArray()));
        original = new String(original.Skip(2).ToArray());
    }
    
    return result;
