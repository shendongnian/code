    public static string MySqlEscape(object value)
    {
        string val = value.ToString();
        if (val.Contains("'"))
            return val.Replace("'", "''");
        else
            return val;
    }
