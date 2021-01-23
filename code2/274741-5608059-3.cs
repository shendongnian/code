    var doc = XDocument.Parse(xmlStr);
    var name = "Hellcode";
    var settings =
        doc.Element("storage")
           .Elements("Save")
           .Where(e => e.Attribute("Name").Value == name)
           // or if using XPath, the above could be replaced with:
    //  doc.XPathSelectElements(String.Format("/storage/Save[@Name='{0}']", name))
           .Select(e => new
           {
               Seconds = (int)e.Element("Seconds"),
               Minutes = (int)e.Element("Minutes"),
               Hours   = (int)e.Element("Hours"),
               Days    = (int)e.Element("Days"),
               Months  = (int)e.Element("Months"),
               Years   = (int)e.Element("Years"),
               Health  = (int)e.Element("Health"),
               Mood    = (int)e.Element("Mood"),
           })
           .SingleOrDefault();
    Trace.WriteLine("settings: " + settings);
