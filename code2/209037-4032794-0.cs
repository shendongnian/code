    public void WriteXmlDocument(XmlDocument document)
    {
        if (document == null)
        {
            throw new ArgumentNullException("document");
        }
    
        using (XmlNodeReader nodeReader = new XmlNodeReader(document))
        {
            while (nodeReader.Read())
            {
                Console.WriteLine(nodeReader.Value);
            }
        };
    }
