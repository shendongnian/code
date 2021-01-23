    public void Save(string filename)
    {
        var serializer = new BinaryFormatter();
        using (var stream = File.Create(filename))
        {
            serializer.Serialize(stream, dict);
        }
    }
    public void Load(string filename)
    {
        var serializer = new BinaryFormatter();
        using (var stream = File.Open(filename, FileMode.Open))
        {
            dict = (Dictionary<string, Image>)serializer.Deserialize(stream);
        }
    }
