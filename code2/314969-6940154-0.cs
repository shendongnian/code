    string targetFileName = "";
    string[] myWindows = new string[];
    using (XmlTextWriter oXmlTextWriter = new XmlTextWriter(targetFileName , Encoding.UTF8))
    {
      oXmlTextWriter.Formatting = Formatting.Indented;
      oXmlTextWriter.WriteStartDocument();
      oXmlTextWriter.WriteStartElement("tabpage");
      oXmlTextWriter.WriteStartElement("form");
      foreach( string window in myWindows)
      {
         oXmlTextWriter.WriteStartElement("Window");
   
         oXmlTextWriter.WriteElementString("name", nameValue);
         oXmlTextWriter.WriteElementString("age", nameValue);
         oXmlTextWriter.WriteElementString("gender", nameValue);
         oXmlTextWriter.WriteEndElement(); // closing Window tag
      }
      oXmlTextWriter.WriteEndElement(); // closing form tag
      oXmlTextWriter.WriteEndElement(); // closing tabpage tag
      // closing the XML file
      oXmlTextWriter.WriteEndDocument();
      oXmlTextWriter.Flush();
      oXmlTextWriter.Close();
    }
