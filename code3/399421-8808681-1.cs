    static string FormatType(Type t)
    {
        string result = t.Name;
        if (t.IsGenericType)
        {
            result = string.Format("{0}<{1}>",
                result.Split('`')[0],
                string.Join(",", t.GetGenericArguments().Select(FormatType)));
        }
        return result;
    }
