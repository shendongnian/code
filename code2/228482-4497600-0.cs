    List<object> AListObject = new List<object>();
    foreach (object o in AListObject)
    {
        string s = o as string;
        if (s != null)
        {
            cities.Add(s);
        }
    }
