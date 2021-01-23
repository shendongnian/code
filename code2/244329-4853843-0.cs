    private void SerializeToFile(string fileName, object o)
    {
        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            binaryFormatter.Serialize(fileStream, o);
        }
    }
    
    private object DeserializeFromFile(string fileName)
    {
        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
        {
            return binaryFormatter.Deserialize(fileStream);
        }
    }
