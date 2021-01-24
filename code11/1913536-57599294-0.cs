    public virtual Dictionary<string, string> SmallDict
    {
        get
        {
            return BigDict.ToDictionary(x => x.Key, x => x.Value.ElemFromStruct);
        }
        set
        {
            BigDict = value.ToDictionary(x => x.Key,
                x => new SomeStruct {ElemFromStruct = x.Value});
        }
    }
