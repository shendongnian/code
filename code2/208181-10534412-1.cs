    public Dictionary<String, Foo> Merge(XElement element1, XElement element2)
    {
        IEnumerable<Foo> firstFoos = GetXmlData(element1); // parse 1st set from XML
        IEnumerable<Foo> secondFoos = GetXmlData(element2); // parse 2nd set from XML
        var result = firstFoos.Concat(secondFoos)
                              .GroupBy(foo => foo.Name)
                              .Select(grp => grp.First())
                              .ToDictionary(k=>k.Name, v=>v);
    
        return result;
    }
