    private List<A> Load()
    {
        string file = "filepath";
        List<A> listofa = new List<A>();
        XmlSerializer formatter = new XmlSerializer(A.GetType());
        FileStream aFile = new FileStream(file, FileMode.Open);
        byte[] buffer = new byte[aFile.Length];
        aFile.Read(buffer, 0, (int)aFile.Length);
        MemoryStream stream = new MemoryStream(buffer);
        return (List<A>)formatter.Deserialize(stream);
    }
    private void Save(List<A> listofa)
    {
        string path = "filepath";
        FileStream outFile = File.Create(path);
        XmlSerializer formatter = new XmlSerializer(A.GetType());
        formatter.Serialize(outFile, listofa);
    }
