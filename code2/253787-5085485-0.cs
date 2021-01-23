    using (var fStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
    using (var m = new MemoryStream())
    using (var c = new CryptoStream(m, encryptor, CryptoStreamMode.Write))
    {
        foreach (Article article in articles)
        {
            // ...
            c.Write(data, 0, data.Length);
            byte[] original = new byte[32];
            original = m.ToArray();
            m.Position = 0;
            fStream.Write(original, 0, original.Length);
        }
    }
