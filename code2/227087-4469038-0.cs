    public static byte[] Compress(string text)
    {
        if (string.IsNullOrEmpty(text))
            return null;
        byte[] raw = Encoding.UTF8.GetBytes(text);
        using (var ms = new MemoryStream())
        {
            using (var compress = new GZipStream (ms, CompressionMode.Compress))
            {
                compress.Write(raw, 0, raw.Length);
                compress.Close();
                return ms.ToArray();
            }
        } 
    }
