    private Dictionary<EnumType, Action<param1Type,param2Type,etc> strategies = 
    new Dictionary<EnumType, Action<param1Type, param2Type, etc>();
...
    private void LoadDictionary()
    {
    strategies.Add(enumType.Option1, Method1);
    strategies.Add(enumType.Option2, Method2);
    ...
    }
