    public static void ReplaceData(string filename, int position, byte[] data)
    {
        using (Stream stream = File.Open(filename, FileMode.Open))
        {
            stream.Position = position;
            stream.Write(data, 0, data.Length);
        }
    }
