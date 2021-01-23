    public static string ConvertToWindowsNewlines(string value)
    {
        value = value.Replace("\r\n", "\n");
        value = value.Replace("\n", "\r\n");
        return value;
    }
