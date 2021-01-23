    void Print(IDictionary dict)
    {
        foreach (var key in dict.Keys)
        {
            var value = dict[key];
            Print(key + " " + value);
        }
    }
    void Print(object o)
    {
        if (o == null || o.GetType().IsValueType || o is string)
        {
            Console.WriteLine(o ?? "*nil*");
            return;
        }
    }
    void Print(string s)
    {
        Console.WriteLine(s);
    }
    void Print(IEnumerable ie)
    {
        foreach (dynamic obj in ie)
        {
            Print(obj);
        }
    }
