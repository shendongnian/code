        string path = Path.Combine(Server.MapPath("."), "App_Data\\XMLData.xml");
        XDocument doc = XDocument.Load(path);
        XElement myData = doc.Elements("pdata").Single();
        myData.ReplaceNodes(
            new XElement("name", NameText.Text.Trim()),
            new XElement("age", AgeText.Text.Trim())
        );
        doc.Save(path);
