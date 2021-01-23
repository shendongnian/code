    [OperationContract]
    public List<Dictionary<int, object>> TestDictionaryGet()
    {
        var resultList = new List<Dictionary<int, object>>();
        Dictionary<int, object> retDict = new Dictionary<int, object>();
        retDict.Add(1, new QualifiedNumber(new decimal(1.2), "<"));
        retDict.Add(2, "pass a simple string");
        resultList.Add(retDict);
        return resultList;
    }
