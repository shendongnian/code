    static void Main()
    {
       Dictionary<string, string> mySettings = new Dictionary<string, string>();
       object o = mySettings;
       SaveSettings(ref o);
       // o now has an item.
    }
    static void SaveSettings(ref object o)
    {
        var d = o as Dictionary<string, string>;
        d.Add("Some", "String");
    }
