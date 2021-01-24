    public static string EnumSize(this Type type)
    {
        if (!type.IsEnum)
        {
            throw new InvalidOperationException("EnumSize only applies to enums");
        }
        
        EnumSizeAttribute attribute = type.GetCustomAttribute<EnumSizeAttribute>();
    
        return attribute?.Value.ToString();
    }
