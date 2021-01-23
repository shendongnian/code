     1 public static byte[] Encrypt(string data, byte[] key, byte[] iv)
     2 {
     3    MemoryStream memoryStream = GetMemoryStream();
     4    using (DESCryptoServiceProvider cryptograph = new DESCryptoServiceProvider())
     5    {
     6        CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptograph.CreateEncryptor(key, iv), CryptoStreamMode.Write);
     7        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
     8        {
     9            streamWriter.Write(data);
    10            return memoryStream.ToArray();
    11        }
    12    }
    13 }
    14
    15 /// <summary>
    16 /// Gets the memory stream.
    17 /// </summary>
    18 /// <returns>A new memory stream</returns>
    19 private static MemoryStream GetMemoryStream()
    20 {
    21     MemoryStream stream;
    22     MemoryStream tempStream = null;
    23     try
    24     {
    25         tempStream = new MemoryStream();
    26
    27         stream = tempStream;
    28         tempStream = null;
    29     }
    30     finally
    31     {
    32         if (tempStream != null)
    33             tempStream.Dispose();
    34     }
    35     return stream;
    36 }
