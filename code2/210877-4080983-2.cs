    using (var mem = new MemoryStream())
    {
        mem.Write(new byte[] { 0x1f, 0x8b, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00 }, 0, 8);
        mem.Write(inputBytes, 0, inputBytes.Length);
        mem.Position = 0;
        using (var gzip = new GZipStream(mem, CompressionMode.Decompress))
        using (var reader = new StreamReader(gzip))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    }
