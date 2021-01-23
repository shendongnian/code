    public class Document
    {
      public string Name { get; set; }
      public string Subject { get; set; }
      
      public void Export(string path)
      {
        // you should use a try-catch-statement, that's just the way it works
        XmlSerializer serializer = new XmlSerializer(typeof(Document));
        TextWriter tr = new StreamWriter(path);
        serializer.Serialize(tr, this);
        tr.Close();
      }
    
      public static Document Import(string path)
      {
        // you should use a try-catch-statement, that's just the way it works
        XmlSerializer serializer = new XmlSerializer(typeof(Document));
        TextReader tr = new StreamReader(path);
        Document document = (Document)serializer.Deserialize(tr);
        tr.Close();
        return document;
      }
    }
