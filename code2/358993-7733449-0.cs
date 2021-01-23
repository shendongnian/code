    var types = new StringDictionary();
    IEnumerator<string> enumerator = streetTypes.Split('|').AsEnumerable().GetEnumerator();
    using (IEnumerator<string> enumerator = streetTypes.Split('|').AsEnumerable().GetEnumerator())
    {
        while(enumerator.MoveNext())
        {
            string first = enumerator.Current;
            if (!enumerator.MoveNext()) 
                break;
            types.Add(first, enumerator.Current);
        }
    }
