    IList list = new ArrayList();
    list.Add("z");
    list.Add("a");
    list.Add("c");
    
    IEnumerable<string> ordered =
        from string item in list
        orderby item
        select item;
        
    foreach (var s in ordered)
    {
        Console.WriteLine(s);
    }
