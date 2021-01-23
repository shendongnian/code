    using (var libraryClient = new MyApplication.LibraryServiceReference.LibraryServiceClient())
    {
        var book = libraryClient.GetBook();
        
        var stringBuilder = new StringBuilder();
        using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder))
        {
            xmlWriter.WriteStartElement("Books", "http://example.com/library");
            var serializer = new XmlSerializer(book.GetType(), "http://example.com/library");
            serializer.Serialize(xmlWriter, book);
            xmlWriter.WriteEndElement();
        }
            
        return stringBuilder.ToString();
    }
