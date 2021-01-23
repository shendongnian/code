    public static string ConvertToString(this IEnumerable list)
    {
        StringBuilder sb = new StringBuilder();
        foreach (object item in list)
        {
            sb.Append(item.ToString());
        }
        return sb.ToString();
    }
