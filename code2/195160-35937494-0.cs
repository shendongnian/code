    // extension method using lambda parameters
    public static Dictionary<string, T> QueryDictionary<T>(
        this Dictionary<string, T> myDict, 
        Expression<Func<KeyValuePair<string,T>, bool>> fnLambda)
    {
        return myDict.AsQueryable().Where(fnLambda).ToDictionary(t => t.Key, t => t.Value);
    }
