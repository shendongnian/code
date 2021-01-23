    public void Save(string fileName)
    {
        //first serialize the object to memory stream,
        //in case of exception, the original file is not corrupted
        using (MemoryStream ms = new MemoryStream())
        {
            var writer = new System.IO.StreamWriter(ms);    
            var serializer = new XmlSerializer(this.GetType());
            serializer.Serialize(writer, this);
            writer.Flush();
            
            //if the serialization succeed, rewrite the file.
            File.WriteAllBytes(fileName, ms.ToArray());
        }
    }
