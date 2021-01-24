    public static XmlDocument LoadOrCreateXmlDocument(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        string fileName = Path.Combine(folderPath + @"\XMLfile.xml");
        if (TryLoadXmlDocument(fileName, out var document))
        {
            return document;
        }
        XmlDocument newDocument = new XmlDocument();
        newDocument.LoadXml("<?xml version=\"1.0\"?> \n" +
                            "<elements> \n" +
                            "</elements>");
        return newDocument;
    }
    public static bool TryLoadXmlDocument(string fileName, out XmlDocument document)
    {
        document = new XmlDocument();
        if (File.Exists(fileName))
        {
            try
            {
                document.Load(fileName);
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }
        return false;
    }
