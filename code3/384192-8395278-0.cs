    public static byte[] EncryptBinaryToBytes(Binary document, byte[] iv)
    {
        byte[] key = GetAppKey();
        byte[] encrypted;
    
        using (AesCryptoServiceProvider aesCsp = new AesCryptoServiceProvider())
        {
            aesCsp.Key = key;
            aesCsp.IV = iv;
    
            ICryptoTransform encryptor = aesCsp.CreateEncryptor(aesCsp.Key, aesCsp.IV);
    
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(document);
                    }
                }
                // Dipose() is called on the CryptoStream, which in turn calls Close(),
                // which calls FlushFinalBlock().
                msEncrypt.Close(); // No more writes to MemoryStream after this,
                // but you can still call ToArray().
                encrypted = msEncrypt.ToArray();
            }
        }
        // return the encrypted document
        return encrypted;
    }
    
    // Decrypt document
    public static byte[] DecryptBytesToBytes(byte[] document, byte[] iv) 
    {
        byte[] key = GetAppKey();
    
        using (AesCryptoServiceProvider aesCsp = new AesCryptoServiceProvider())
        {
            aesCsp.Key = key;
            aesCsp.IV = iv;
    
            ICryptoTransform decryptor = aesCsp.CreateDecryptor(aesCsp.Key, aesCsp.IV);
    
            using (MemoryStream msDecrypt = new MemoryStream())
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swDecrypt = new StreamWriter(csDecrypt))
                    {
                        swDecrypt.Write(document);
                    }
                }
                msDecrypt.Close();
                byte[] decrypted = msDecrypt.ToArray();
                // return the unencrypted document
                return decrypted;
            }
        }
    }
