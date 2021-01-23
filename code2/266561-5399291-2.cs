    public static string ToStringLinq(this object o)
    {
        return o.GetType().FullName 
            + Environment.NewLine 
            + string.Join(Environment.NewLine, (from p in o.GetType().GetProperties()
                                                select string.Format("{0}{1}{2}", p.Name, ':', p.GetValue(o, null))));
    }
