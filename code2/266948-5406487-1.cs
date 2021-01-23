    public Dictionary<A,C> SomeFunction(dic1, dic2)
    {
        var dic3 = new Dictionary<A,C>();
        foreach (var item in dic1)
        { 
             var item2 = dic2.Where(m=>m.Key == item.Value).FirstOrDefault(); 
             if (item2 != null) 
             {
                 dic3.Add(item.Key, item2.Value);
             } 
        }
        return dic3
    }
