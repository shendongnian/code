    public string(string s)
    {
    System.Globalization.CultureInfo c = new System.Globalization.CultureInfo("en-us", false)
    System.Globalization.TextInfo t = c.TextInfo;
    
    return t.ToTitleCase(s);
    }
