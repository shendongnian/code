    XPathNodeIterator iter = xml.CreateNavigator().Select("//test/name");
    while (iter.MoveNext())
    {
        var nav = iter.Current;
        string name = nav.Value;
        Console.WriteLine(name);
    }
