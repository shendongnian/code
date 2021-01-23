    Dictionary<string,string> interner =
        new Dictionary<string,string>();
    foreach(Item item in list) {
        string s;
        if(interner.TryGetValue(item.Name, out s))
            item.Name = s;
        else
            interner.Add(item.Name, item.Name);
    }
