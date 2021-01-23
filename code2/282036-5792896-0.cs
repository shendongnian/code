    byte[] bytes;
    using (var ms = new MemoryStream())
    using (var bw = new BinaryWriter(ms))
    {
        for (int i = 0; i < 3; i++)
            bw.Write(valueStore[i]);
        bytes = ms.ToArray();
    }
    serverStream.Write(bytes, 0, bytes.Length);
