    {
      XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
      {
        Indent = true,
        IndentChars = "\t",
        NewLineOnAttributes = true
      };
      using (XmlWriter w= XmlWriter.Create("myfile.xml", xmlWriterSettings))
      {
        w.WriteStartDocument();
        w.WriteStartElement("myfile");
        w.WriteElementString("id", id.Text);
        w.WriteElementString("date", dateTimePicker1.Text);
        w.WriteElementString("version", ver.Text);
        w.WriteEndElement();
        w.WriteEndDocument();
      }
    }
