    public static Dictionary<string, object> GeneratePropertiesDictionary(object myClass)
    {
        return myClass.GetType()
                      .GetProperties()
                      .Where(p => p.CanRead)
                      .ToDictionary(p => p.Name, p => p.GetValue(myClass, null));
    }
