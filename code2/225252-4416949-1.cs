    Dictionary<string,string> interner =
        new Dictionary<string,string>();
    foreach(Item item in list) {
        string s, name = item.Name;
        if(interner.TryGetValue(name, out s))
            item.Name = s;
        else
            interner.Add(name, name);
    }
