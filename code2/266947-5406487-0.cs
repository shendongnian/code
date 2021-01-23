    public Dictionary<A,C> SomeFunction(dic1, dic2)
    {
        var dic3 = new Dictionary<A,C>();
        foreach (var item in dic1)
        { 
             dic3.Add(item.Key, dic2.Where(m=>m.Key == item.Value).FirstOrDefault().Value);
        }
        return dic3
    }
