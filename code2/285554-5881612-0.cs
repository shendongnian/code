    var docx = XDocument.Load("someUri");
    
    var elements = docx.Elements(XName.Get("XProperty")).Where(x => x.Attributes().Count(a => a.Name == XName.Get("Name") && a.Value == "SerialNumber") > 0);
    
    foreach (var e in elements)
    {
        if (e.Elements().Count(x => x.Name == XName.Get("Value")) == 1)
        {
            e.Elements().Single(x => x.Name == XName.Get("Value")).Value = "XYZ";
        }
        else
        {
            e.Add(new XElement(XName.Get("Value"), "XYZ"));
        }
    }
