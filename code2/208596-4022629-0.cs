    public void Serialize(Dictionary<string, int> dictionary, Stream stream)
    {
        BinaryWriter writer = new BinaryWriter(stream);
        writer.Write(dictionary.Count);
        foreach (var kvp in dictionary)
        {
            writer.Write(kvp.Key);
            writer.Write(kvp.Value);
        }
        writer.Flush();
    }
    public Dictionary<string, int> Deserialize(Stream stream)
    {
        BinaryReader reader = new BinaryReader(stream);
        int count = reader.ReadInt32();
        var dictionary = new Dictionary<string,int>(count);
        for (int n = 0; n < count; n++)
        {
            var key = reader.ReadString();
            var value = reader.ReadInt32();
            dictionary.Add(key, value);
        }
        return dictionary;                
    }
