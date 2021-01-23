    static void Dump(object o, TextWriter output)
    {
        if (o == null)
        {
            output.WriteLine("null");
            return;
        }
    
        var properties =
            from prop in o.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
            where prop.CanRead
            && !prop.GetIndexParameters().Any() // exclude indexed properties to keep things simple
            select new
            {
                prop.Name,
                Value = prop.GetValue(o, null)
            };
    
        output.WriteLine(o.ToString());
        foreach (var prop in properties)
        {
            output.WriteLine(
                "\t{0}: {1}",
                prop.Name,
                (prop.Value ?? "null").ToString());
        }
    }
