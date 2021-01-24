    public static string GetCategory(this Enum val)
    {
        return val.GetAttribute<CategoryAttribute>()?.Category ?? string.Empty;
    }
    
    
    public static string GetDescription(this Enum val)
    {
        return val.GetAttribute<DescriptionAttribute>()?.Description ?? string.Empty;
    }
