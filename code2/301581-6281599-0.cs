    ...
    public ToStringGenerator()
    {
        SupportedMethods = new[]
            {
                ReflectionHelper.GetMethodDefinition<object>(x => x.ToString()),
                ReflectionHelper.GetMethodDefinition<int>(x => x.ToString()),
            };
    }
    ...
