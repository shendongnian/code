    public IEnumerator Enumerate(IEnumerable enumerable)
    {
        // List implements IEnumerable, but could be any collection.
        List<string> list = new List<string>(); 
        
        foreach(string value in enumerable)
        {
            list.Add(value + "roxxors");
        }
        return list.GetEnumerator();
    }
