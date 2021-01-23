    private byte[] ConvertStringToBytes(string input)
    {
        MemoryStream stream = new MemoryStream();
        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.Write(input);
            writer.Flush();
        }
        return stream.ToArray();
    }
