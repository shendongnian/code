    public static DumpFields(this Object dumpWhat)
    {
        foreach(FieldInfo fld in dumpWhat.GetType().GetFields())
            Console.WriteLine("{0} = {1}", fld.Name, fld.GetValue(dumpWhat, BindingFlags.GetField, null, null, null).ToString());
    }
