    public void GenerateXML<T>(string filePath)
    {
        var dataForXML = app.db.Table<T>().ToList();
        XmlSerializer serializer = new XmlSerializer( typeof(List<T>) );
        TextWriter writer = new StreamWriter(filePath);
        serializer.Serialize(writer,dataForXML);
        writer.Close();
    }
