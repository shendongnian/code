    var builder = new StringBuilder();
    using (var writer = XmlWriter.Create(builder))
    {
        writer.WriteStartElement("AlbumDetails");
        writer.WriteStartElement("Album");
        writer.WriteAttributeString("Id", "203");
        writer.WriteElementString("Venue", "Wallingford School");
        
        writer.WriteStartElement("PrintPackage");
        .... etc.
  
        writer.WriteEndElement(); // close PrintPackage
        writer.WriteEndElement(); // close Album
        writer.WriteEndElement(); // close AlbumDetails
    }
    Console.WriteLine(builder.ToString());
