    public static Dictionary<string, object> RecursivelyDictionary(
        IDictionary<string, object> dictionary)
    {
        var concrete = new Dictionary<string, object>();
    
        foreach (var element in dictionary)
        {
            var cast = element.Value as IDictionary<string, object>;
            var value = cast == null ? element.Value : RecursivelyDictionary(cast);
            concrete.Add(element.Key, value);
        }
    
        return concrete;
    }
