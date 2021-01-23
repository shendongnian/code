    var lookup = elements.ToLookup(
           x => new {
                Name = x.Name.LocalName,
                Store = x.Element(XName.Get("Store", "")).Value,
                Section =  x.Element(XName.Get("Section", "")).Value},
           x =>  x.Element(XName.Get("Val", ""))
        );
    foreach (DataSource Data in DataLst)
    { 
        XElement xmlElem = lookup[
              new {Data.Name, Data.Store, Data.Section}].Single();
        xmlElem.ReplaceWith(new XElement(XName.Get("Val", ""), Data.Value));
    }
