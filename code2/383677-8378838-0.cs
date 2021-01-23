    static void Add(List<object> list, XPathNavigator thisNavigator)
    {
        string s = thisNavigator.ValueAsString;
        double d;
        if(double.TryParse(s, out d))
        {
            list.Add(d);
        }
        else
        {
            list.Add(s);
        }
    }
