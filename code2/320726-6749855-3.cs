    public static string PrettyFormat(this Enum enumValue)
    {
        string text = enumValue.ToString();
        EnumDisplayNameAttribute displayName = (EnumDisplayNameAttribute)enumValue.GetType().GetField(text).GetCustomAttributes(typeof(EnumDisplayNameAttribute), false).SingleOrDefault();
        if (displayName != null)
            text = displayName.DisplayName;
        else
            text = text.PrettySpace().Capitalize(true);
        return text;
    }
