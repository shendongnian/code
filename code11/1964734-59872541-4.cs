    internal ACResult[]  FilterResults(object objType)
    {
        List<ACResult> ret = new List<ACResult>();
        foreach (ACResult result in cachedResults)
        {
            if (result.ObjectType == objType)
                ret.Add(result);
        }
        return ret.ToArray();
    }
