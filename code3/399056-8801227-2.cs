    public string FindPrimaryKey<T>(ClassMap<T> map)
    {
        var providersInfo = map.GetType().BaseType.GetField("providers", BindingFlags.Instance | BindingFlags.NonPublic);
        dynamic providersValue = providersInfo.GetValue(map);
        var Id = providersValue.Id
        var PKName = ((List<string>) Id.GetType().GetField("columns", BindingFlags.Instance | BindingFlags.NonPublic)
                                                 .GetValue(Id)).SingleOrDefault();
        return PKName;
     }
    
