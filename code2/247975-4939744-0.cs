    XsltArgumentList xslArg = new XsltArgumentList();
    string name = "John";
    xslArg.AddParam("name", "", name);
    DateTime d = DateTime.Now;
    xslArg.AddParam("date", "", d.ToString());
    FieldInfo fi = xslArg.GetType().GetField("parameters", BindingFlags.NonPublic | 
                                                           BindingFlags.Instance);
    System.Collections.Hashtable parameters = fi.GetValue(xslArg) as System.Collections.Hashtable;
    if (parameters != null)
    {
        foreach (System.Collections.DictionaryEntry item in parameters)
            Console.WriteLine("{0} | {1}", item.Key, item.Value);
    }
