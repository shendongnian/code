    public IEnumerable<FieldInfo> GetFields(Type type)
    {
        return type
            .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
			.Where(f => f.GetCustomAttribute<CompilerGeneratedAttribute>() == null);
    }
