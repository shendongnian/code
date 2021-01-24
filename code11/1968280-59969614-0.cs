    ASCII85 ascii85 = new ASCII85();
    ascii85.EnforceMarks = false;
    byte[] ascii85Decoded = ascii85.decode(rawStreamChars);
    using (MemoryStream stream = new MemoryStream(ascii85Decoded))
    {
        // Remove 2 bytes zlib header
        stream.ReadByte();
        stream.ReadByte();
        using (DeflateStream decompressionStream = new DeflateStream(stream, CompressionMode.Decompress))
        using (MemoryStream result = new MemoryStream())
        {
            decompressionStream.CopyTo(result);
            Console.Out.WriteLine(Encoding.GetEncoding("windows-1252").GetString(result.ToArray()));
        }
    }
