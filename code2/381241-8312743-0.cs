    class MyFile
    {
        public byte[] Data;
        public string FileName;
    }
    List<MyFile> files = GetFiles();
    using (MemoryStream stream = new MemoryStream())
    {
        // Serialise
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, files);
        // Deserailise
        stream.Position = 0;
        List<MyFile> deserialisedFiles = (List<MyFile>)formatter.Deserialize(stream);
        SaveFiles(deserialisedFiles);
    }
