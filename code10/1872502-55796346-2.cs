    public static string GetCategory(this Enum val)
    {
		return val.GetType()
              .GetField(val.ToString())
              .GetCustomAttribute<CategoryAttribute>(false)?.Category ?? string.Empty;
    }
    public static string GetDescription(this Enum val)
    {
		return val.GetType()
              .GetField(val.ToString())
              .GetCustomAttribute<DescriptionAttribute>(false)?.Description ?? string.Empty;
    }
