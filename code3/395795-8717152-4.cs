    public static void DumpProperties(this Object dumpWhat)
    {
        foreach(PropertyInfo prop in dumpWhat.GetType().GetProperties())
            Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(dumpWhat, BindingFlags.GetProperty, null, null, null).ToString());
    }
