    public byte[] EncryptData(byte[] input, string password, byte[] salt)
    {
        using (var kdf = new Rfc2898DeriveBytes("", salt))
        {
            using (var aesCipher = new AesCryptoServiceProvider())
            {
                aesCipher.Key = kdf.GetBytes(16); //use 128-bit AES
                aesCipher.IV = kdf.GetBytes(16);
                aesCipher.KeySize = 128;
                aesCipher.BlockSize = 128;
    
                ICryptoTransform encryptor = aesCipher.CreateEncryptor();
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(input, 0, input.Length);
                    }
                    return memoryStream.ToArray();
                }
            }
        }
    }
