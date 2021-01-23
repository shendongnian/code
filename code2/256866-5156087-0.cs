    public static DateTime ParseWithDefault(string text, DateTime defaultValue)
    {
        DateTime ret;
        if (!DateTime.TryParse(text, out ret))
        {
            ret = defaultValue;
        }
        return ret;
    }
