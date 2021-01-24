    var elements = root.Descendants(elementName).Descendants()
        .Where(x => (string)x.Attribute("name") == "LastResolvedDate");
    
    foreach (var item in elements)
    {
        item.Attribute("name").Remove();
        item.Add(new XAttribute("renamed_new_name", "LastResolvedDate"));
    }
