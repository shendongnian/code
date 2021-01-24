    var doc = XDocument.Load("test.xml");
    var sb = new StringBuilder();
    bool flag = true;
    var nodes = doc.Root.Elements("table").Elements("items").ToList();
    for (int i = 0; i < nodes.Count; i++)
    {
        sb.Append(nodes[i].Value);
        if (i == nodes.Count - 1)
            break;
        sb.Append(flag ? ", " : " / ");
        flag = !flag;
    }
    
    var newDoc = new XDocument(
        new XElement("root",
            new XElement("table",
                new XElement("items", sb.ToString()))));
    newDoc.Save(Console.Out);
