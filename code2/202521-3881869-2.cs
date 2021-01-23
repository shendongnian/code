    public static string ToStringWithoutExtraCommas(this object[] array)
    {
        StringBuilder sb = new StringBuilder();
        foreach (object o in array)
        {
            
            if (o != null || o is string && !string.IsNullOrEmpty((string)o))
                sb.Append(o.ToString()).Append(",");
        }
        sb.Remove(sb.Length - 1, 1);
        return sb.ToString();
    }
