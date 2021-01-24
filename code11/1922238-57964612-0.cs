    static byte[] AesEncrypt(byte[] data, byte[] key)
    {
        if (data == null || data.Length <= 0)
        {
            throw new ArgumentNullException($"{nameof(data)} cannot be empty");
        }
    
        if (key == null || key.Length != AesKeySize)
        {
            throw new ArgumentException($"{nameof(key)} must be length of {AesKeySize}");
        }
    
        using (var aes = new AesCryptoServiceProvider
        {
            Key = key,
            Mode = CipherMode.CBC,
            Padding = PaddingMode.PKCS7
        })
        {
            aes.GenerateIV();
            var iv = aes.IV;
            using (var encrypter = aes.CreateEncryptor(aes.Key, iv))
            using (var cipherStream = new MemoryStream())
            {
                using (var tCryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
                using (var tBinaryWriter = new BinaryWriter(tCryptoStream))
                {
                    // prepend IV to data
                    cipherStream.Write(iv);
                    tBinaryWriter.Write(data);
                    tCryptoStream.FlushFinalBlock();
                }
                var cipherBytes = cipherStream.ToArray();
    
                return cipherBytes;
            }
        }
    }
