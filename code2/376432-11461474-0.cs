    /// <summary>
    /// Converts .pfx file to .snk file.
    /// </summary>
    /// <param name="pfxData">.pfx file data.</param>
    /// <param name="pfxPassword">.pfx file password.</param>
    /// <returns>.snk file data.</returns>
    public static byte[] Pfx2Snk(byte[] pfxData, string pfxPassword)
    {
        // load .pfx
        var cert = new X509Certificate2(pfxData, pfxPassword, X509KeyStorageFlags.Exportable);
    
        // create .snk
        var privateKey = (RSACryptoServiceProvider)cert.PrivateKey;
        return privateKey.ExportCspBlob(true);
    }
