    XmlDocument doc = new XmlDocument();
    doc.Load(xml);
    XmlNodeList values = doc.GetElementsByTagName("value");
    string NameEx = "Properties.Name";
    for (int i = 0; i < values.Count; i++)
    {
     if (values[i].InnerText == NameEx)
     {
        comboBox1.Items.Add(values[i + 1].InnerText);
        i++;
     }
    }
