    public static void DumpProperties(this Object dumpWhat)
    {
        foreach(PropertyInfo prop in dumpWhat.GetType().GetProperties())
        {
            string propVal = prop.GetValue(dumpWhat, BindingFlags.GetProperty, null, null, null) as string;
            if (propVal != null)
                Console.WriteLine("{0} = {1}", prop.Name, propVal);
        }
    }
