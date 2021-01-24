    public static string GetDescription<T>(this T enumVal) where T : Enum {
        var type = enumVal.GetType();
        var memberInfo = type.GetFields()[1+Convert.ToInt32(enumVal)];
        var attrib = memberInfo.GetCustomAttribute<DescriptionAttribute>();
        return attrib?.Description ?? null;
    }
