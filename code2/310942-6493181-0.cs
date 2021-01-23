    using (XmlReader reader = XmlReader.Create(inputUrl))
    {
      reader.MoveToContent();
      while (reader.Read())
      {
        if (reader.NodeType == XmlNodeType.Element)
        {
          if (reader.Name == elementName)
          {
            XElement el = XNode.ReadFrom(reader) as XElement;
           
          }
.....
