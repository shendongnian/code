    public static string EnumSize(this Type type)
    {
        EnumSizeAttribute attribute = type.GetCustomAttribute<EnumSizeAttribute>();
    
        return attribute?.Value.ToString();
    }
    string size = Memories.EnumSize();
