    List<string> enumValues = new List<string>();
    foreach(Type t in AppDomain.CurrentDomain.GetAssemblies().Select(a=>a.GetTypes().Where(t=>t.IsEnum)))
    {
        enumValues.AddRange(Enum.GetNames(t));
    }
