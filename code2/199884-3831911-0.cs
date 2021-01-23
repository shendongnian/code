    MemoryStream memoryStream = new MemoryStream();
            
    var cryptoStream = (CryptoStream)null;
    try
    {
        using (var cryptograph = new DESCryptoServiceProvider())
        {
            cryptoStream = new CryptoStream(memoryStream, ..., ...);
            using (var writer = new StreamWriter(cryptoStream))
            {
                writer.Write(data);
            }
        }
    }
    finally
    {
        if (cryptoStream != null)
            cryptoStream.Dispose();
    }
    return memoryStream.ToArray();
    
