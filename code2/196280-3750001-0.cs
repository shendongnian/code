    List<string> item = new List<string>();
    item.Add("a");
    item.Add("as");
    item.Add("b");
    item.Add("fgs");
    item.Add("adsd");
    
    List<string> list = new List<string>();
    list.Add("a");
    list.Add("b");
    
    var result = item.FindAll(o =>
        list.Any(a => o.StartsWith(a))
    );
