    public IDictionary<A, C> SomeFunction<A, B, C>(IDictionary<A, B> dic1, IDictionary<B, C> dic2)
    {
        var dic3 = new Dictionary<A, C>();
        foreach (var item in dic1)
        {
            var a = item.Key;
            var b = item.Value;
            if (dic2.ContainsKey(b))
            {
                var c = dic2[b];
                dic3.Add(a, c);
            }
        }
    
        return dic3;
    }
