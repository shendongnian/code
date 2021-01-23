    public static string DumpObject<T>(T obj)
    {
        StringBuilder sb = new StringBuilder();
            
        var properties = typeof(T).GetProperties(
                         BindingFlags.Instance | BindingFlags.Public);
        foreach (var p in properties)
        {
            object x = p.GetGetMethod().Invoke(obj, null);
            x = StripDate(x);
            sb.Append(p.Name).Append(": ").Append(x).AppendLine();
        }
        return sb.ToString();
    }
