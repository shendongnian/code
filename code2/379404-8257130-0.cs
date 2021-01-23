    public static String GetAString(object media)
    {
        PropertyInfo propName = media.GetType().GetProperty("name");
        if (propName != null)
            return propName.GetValue(media, null);
        return "";
    }
