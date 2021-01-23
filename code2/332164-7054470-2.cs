    private byte[] StringToByteArray(string str)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream();
        binaryFormatter.Serialize(memoryStream, str);
        memoryStream.Seek(0, 0);
        return memoryStream.ToArray(); 
    }
    private string ByteArrayToString(byte[] byteArray)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream();
        memoryStream.Write(byteArray, 0, (int)byteArray.Length);
        memoryStream.Seek(0, 0);
        return (string)binaryFormatter.Deserialize(memoryStream);
    }
