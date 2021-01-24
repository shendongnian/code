    public static string Decompress(Stream input)
    {
        // note this buffer size is REALLY small. 
        // You could stick with the default buffer size of the StreamReader (1024)
        const int BUFFER_SIZE = 32;
        string result = null;
        using (var gis = new GZipStream(input, CompressionLevel.Optimal, leaveOpen: true))
        using (var reader = new StreamReader(gis, Encoding.UTF8, true, BUFFER_SIZE))
        {
            result = reader.ReadToEnd();
        }
    
        return result;
    }
