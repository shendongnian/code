    System.Xml.XmlReader reader = System.Xml.XmlReader.Create("XML URI here");
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    while (reader.Read())
    {
    	sb.Append(reader.ReadOuterXml());
    }
    reader.Close();
    txtXML.InnerText = sb.ToString();
    txtXML.Visible = true;
