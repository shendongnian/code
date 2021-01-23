    public void Save(string FileName)
    {
        using (var writer = new System.IO.StreamWriter(FileName))
        {
            var serializer = new XmlSerializer(this.GetType());
            serializer.Serialize(writer, this);
            writer.Flush();
        }
    }
