    using System.Xml.Serialization;
    using System.IO;
    
    // Load the book from the file.
    XmlSerializer serializer = new XmlSerializer(typeof(Book));
    reader = new StreamReader(filePathName);
    Book book = (Book)serializer.Deserialize(reader);
    reader.Close();
    
    if (book.Name.Contains(myQuery))
    {
        // We have a match.
    }
