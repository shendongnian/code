    public string DecodeStringFromBase64(string stringToDecode, StringCompressionType compressionType)
    {
        //decode the string to decompress and get the unicode representation of the compressed data 
        var BytesToDecode = Convert.FromBase64String(stringToDecode);
        if (compressionType!= StringCompressionType.None)
        {
            using (MemoryStream DataCompressionMemoryStream = new MemoryStream(BytesToDecode))
            {
                //reset the position of the stream to zero
                DataCompressionMemoryStream.Position = 0;
                switch (compressionType)
                {
                    case StringCompressionType.GZipCompression:
                        using (GZipStream DecompressionStream = new GZipStream(DataCompressionMemoryStream, CompressionMode.Decompress, false))
                            Array.Resize(ref BytesToDecode, DecompressionStream.Read(BytesToDecode, 0, BytesToDecode.Length));
                        break;
                    case StringCompressionType.StreamDeflation:
                        using (DeflateStream DecompressionStream = new DeflateStream(DataCompressionMemoryStream, CompressionMode.Decompress))
                            Array.Resize(ref BytesToDecode, DecompressionStream.Read(BytesToDecode, 0, BytesToDecode.Length));
                        break;
                }
            }
        }
        return Encoding.UTF8.GetString(BytesToDecode);
    }
    public enum StringCompressionType
    {
        GZipCompression,
        StreamDeflation,
        None
    }
