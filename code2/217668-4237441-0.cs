      using (XmlTextReader reader = new XmlTextReader("C:/whatever.xml"))
      {
        reader.Read();
        XElement permission = (XElement)XElement.ReadFrom(reader);
        string name = permission.Element("CP").Attribute("name").Value;
        foreach (var tab in permission.Element("CP").Elements("tab"))
        {
          string tabName = tab.Attribute("name").Value;
        }
      }
