    private string CompressToLZW(string input)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            ComputeLZW(input, stream);
            stream.Seek(0, SeekOrigin.Begin);
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
