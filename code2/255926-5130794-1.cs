    static dynamic Combine(dynamic item1, dynamic item2)
    {
        var dictionary1 = (Dictionary<string, object>)item1;
        var dictionary2 = (Dictionary<string, object>)item2;
        var result = new ExpandoObject();
        var d = result as IDictionary<string, object>; //work with the Expando as a Dictionary
        foreach (var pair in dictionary1.Concat(dictionary2))
        {
            d[pair.Key] = pair.Value;
        }
        return result;
    }
