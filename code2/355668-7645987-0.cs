    using (var csp    = new TripleDESCryptoServiceProvider())
    using (var enc    = csp.CreateEncryptor(Key, IV))
    using (var stream = File.Open(FileName, FileMode.OpenOrCreate))
    using (var crypto = new CryptoStream(stream, enc, CryptoStreamMode.Write))
    using (var writer = new StreamWriter(crypto, Encoding.UTF8))
    {
        writer.WriteLine("Hello World");
    }
