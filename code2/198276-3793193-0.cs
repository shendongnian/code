    // untested
    void Function(Inline inline1)
    {
        string rSer = XamlWriter.Save(inline1);
        var inline2 = XamlReader.Parse(rSer) as Inline;
        p.Inlines.Add(inline2); 
    }
