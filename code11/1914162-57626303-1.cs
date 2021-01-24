    StringBuilder sb = new StringBuilder();
    string delimiter = ",";
    
    XmlDocument doc = new XmlDocument();
    doc.Load(@"file.xml");
    var paramElements = doc.GetElementsByTagName("Param");
    for (int i = 0; i < paramElements.Count; i++)
    {
        var currentElt = paramElements.Item(i);
        sb.Append(currentElt.Attributes.GetNamedItem("Name").Value);
        sb.Append(delimiter);
        sb.Append(currentElt.Attributes.GetNamedItem("PNum").Value);
        sb.AppendLine();
    }
    
    var path = @"Result.csv";
    File.WriteAllText(path, sb.ToString());
