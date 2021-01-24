    public int Count(string type)
    {
        if(buffer.TryGet(type, out List<Dictionary<string, object>> subset)
        {
            return subset.Count;
        }
        return 0;
     }
