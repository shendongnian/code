    static IEnumerable<PropertyInfo> propertyInfos;
	static MyClass()
	{
		propertyInfos = typeof(MyClass).GetProperties(BindingFlags.Public | BindingFlags.Instance).OrderBy(x => x.Name);
	}
    public override string ToString()
	{
        return $"{GetType().Name}({string.Join("; ", propertyInfos.Select(x => $"{x.Name}: {x.GetValue(this)}"))})";
	}
