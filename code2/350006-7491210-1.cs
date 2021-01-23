    // In the static initializer...
    ValueToDescriptionMap = new Dictionary<T, string>();
    DescriptionToValueMap = new Dictionary<string, T>();
    foreach (T value in Values)
    {
        string description = GetDescription(value);
        ValueToDescriptionMap[value] = description;
        if (description != null && !DescriptionToValueMap.ContainsKey(description))
        {
            DescriptionToValueMap[description] = value;
        }
    }
    private static string GetDescription(T value)
    {
        FieldInfo field = typeof(T).GetField(value.ToString());
        return field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .Cast<DescriptionAttribute>()
                    .Select(x => x.Description)
                    .FirstOrDefault();
    }
