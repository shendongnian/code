    public static void Map(this Control fc, string name, Action<string> assign)
    {
       var fp = fc.Property.Find(i => i.name == name);
       if (fp != null) assign(fp.Value);
    }
