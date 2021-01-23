       private static byte[] Encrypt(byte[] value, byte[] key)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider
                                                          {
                                                              Mode = CipherMode.ECB,
                                                              Padding = PaddingMode.None
                                                          };
            
            MemoryStream memoryStream = new MemoryStream();
            
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(key, key), CryptoStreamMode.Write);
    
            cryptoStream.Write(value, 0, value.Length);
            cryptoStream.Close();
    
            return memoryStream.ToArray();
        }
