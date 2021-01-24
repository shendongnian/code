    var values = new Dictionary<string, string>
    {
        { nameof(TBWVB), TBWVB.Text },
        { nameof(TBWNB), TBWNB.Text }
        //        .... etc ......
    }
    XmlWriter xmlWriter = XmlWriter.Create(PATH);
    xmlWriter.WriteStartDocument();
    xmlWriter.WriteStartElement("Config");
    foreach (var item in values.Keys)
    {
        xmlWriter.WriteStartElement(item);
        xmlWriter.WriteString(values[item]);
        xmlWriter.WriteEndElement();
    }
