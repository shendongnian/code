    public static void Build(string str)
    {
        string localStr = str;
    
        var tree = XmlBuilder.Load();
        foreach (var section tree.Sections)
        {
            localStr += section.Name;
            foreach (var variable in tree.Sections[section].Variables)
            {
                //
            }
        }
        if (tree.Sections[section].Sections.Count > 0)
        {
            // here I want to call Build(null)
        }
    }
