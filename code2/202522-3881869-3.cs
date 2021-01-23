    public static string ToStringWithoutExtraCommas(this object[] array)
    {
        StringBuilder sb = new StringBuilder();
        foreach (object o in array)
        {
            
            if ((o is string && !string.IsNullOrEmpty((string)o)) || o != null)
                sb.Append(o.ToString()).Append(",");
        }
        sb.Remove(sb.Length - 1, 1);
        return sb.ToString();
    }
