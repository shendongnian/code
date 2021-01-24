    /*
    This will be an IEnumerable<XElement> with elements that
    have "Urgency" as the "name" attribute.
    */
    var filteredElements = xml.Elements()
        .Where(x => "Urgency".Equals(x.Attribute("name").Value));
    /*
    This will be an IEnumerable of key value a group with the
    key "Urgency" and the value being the 2 matching elements.
    */
    var groupedElements = filteredElements
        .GroupBy(x => x.Attribute("value").Value);
