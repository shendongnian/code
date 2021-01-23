    public void DictionaryTest()
    {
        IDictionary<int, string> d = GetD() ?? new Dictionary<int, string>();
        d[1] = "ss";
    }
