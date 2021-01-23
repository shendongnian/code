    public byte[] encryptData(byte[] source, string key, bool padding)
    {
        byte[] encryptedSource = null;
       
        byte[] btKeyInBytes = UTF8Encoding.UTF8.GetBytes(key);
        Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(key, btKeyInBytes);
       
        AesManaged encryptor = new AesManaged();
        //encryptor.Mode = CipherMode.CFB; 
        encryptor.KeySize = 128;          // in bits     
        encryptor.Key = new byte[128 / 8];  // 16 bytes for 128 bit encryption     
        encryptor.IV = new byte[128 / 8];
        if (padding) { encryptor.Padding = PaddingMode.PKCS7; }
        else { encryptor.Padding = PaddingMode.None; }
       
     
        using (MemoryStream encryptStream = new MemoryStream())
        {
            using (CryptoStream encStream =
                       new CryptoStream(encryptStream,
                                        encryptor.CreateEncryptor(rfc.GetBytes(16),
                                                                  rfc.GetBytes(16)),
                                        CryptoStreamMode.Write))
            {
                //Read from the input stream, then encrypt and write to the output stream.
                encStream.Write(source, 0, source.Length);
            }
            encryptStream.Flush();
            encryptedSource = encryptStream.ToArray();
        }
        return encryptedSource;
    }
    public byte[] decryptData(byte[] source, string key,bool padding)
    {
        byte[] encryptedSource = null;
        byte[] btKeyInBytes = UTF8Encoding.UTF8.GetBytes(key);
        Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(key, btKeyInBytes);
        AesManaged encryptor = new AesManaged();
        encryptor.Key = new byte[128 / 8];  // 16 bytes for 128 bit encryption     
        encryptor.IV = new byte[128 / 8];
        if (padding) { encryptor.Padding = PaddingMode.PKCS7; }
        else { encryptor.Padding = PaddingMode.None; }
        
  
        using (MemoryStream encryptStream = new MemoryStream())
        {
            using (CryptoStream encStream =
                     new CryptoStream(encryptStream,
                                      encryptor.CreateDecryptor(rfc.GetBytes(16),
                                                                rfc.GetBytes(16)),
                                      CryptoStreamMode.Write))
            {
                //Read from the input stream, then encrypt and write to the output stream.
                encStream.Write(source, 0, source.Length);
            }
            encryptStream.Flush();
            encryptedSource = encryptStream.ToArray();
            
        }
       
        return encryptedSource;
    }
