    private static byte[] UnPem(string pem)
    {
        // This is a shortcut that assumes valid PEM
        // -----BEGIN words-----\nbase64\n-----END words-----
        const string Dashes = "-----";
        int index0 = pem.IndexOf(Dashes);
        int index1 = pem.IndexOf('\n', index0 + Dashes.Length);
        int index2 = pem.IndexOf(Dashes, index1 + 1);
        return Convert.FromBase64String(pem.Substring(index1, index2 - index1));
    }
    ...
    string keyPem = File.ReadAllText("private.key");
    byte[] keyDer = UnPem(keyPem);
    X509Certificate2 certWithKey;
    using (X509Certificate2 certOnly = new X509Certificate2("certificate.cer"))
    using (RSA rsa = RSA.Create())
    {
        // For "BEGIN PRIVATE KEY"
        rsa.ImportPkcs8PrivateKey(keyDer, out _);
        certWithKey = certOnly.CopyWithPrivateKey(rsa);
    }
    using (certWithKey)
    {
        Console.WriteLine(certWithKey.HasPrivateKey);
    }
