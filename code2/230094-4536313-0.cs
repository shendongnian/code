    [ComVisible(false)]
    public static string Join(string separator, params object[] values)
    {
        if (values == null)
        {
            throw new ArgumentNullException("values");
        }
        if ((values.Length == 0) || (values[0] == null))
        {
            return Empty;
        }
        if (separator == null)
        {
            separator = Empty;
        }
        StringBuilder builder = new StringBuilder();
        string str = values[0].ToString();
        if (str != null)
        {
            builder.Append(str);
        }
        for (int i = 1; i < values.Length; i++)
        {
            builder.Append(separator);
            if (values[i] != null)
            {
                str = values[i].ToString();
                if (str != null)
                {
                    builder.Append(str);
                }
            }
        }
        return builder.ToString();
    }
 
