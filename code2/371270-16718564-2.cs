            using (var aes= new AesCryptoServiceProvider()
            {
                Key = PrivateKey,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            })
            {
                var input = Encoding.UTF8.GetBytes(originalPayload);
                aes.GenerateIV();
                var iv = aes.IV;
                using (var encrypter = aes.CreateEncryptor(aes.Key, iv))
                using (var cipherStream = new MemoryStream())
                {
                    using (var tCryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
                    using (var tBinaryWriter = new BinaryWriter(tCryptoStream))
                    {
                        //Prepend IV to data
                        tBinaryWriter.Write(iv);
                        tBinaryWriter.Write(input);
                        tCryptoStream.FlushFinalBlock();
                    }
                    string encryptedPayload = Convert.ToBase64String(cipherStream.ToArray());
                }
            }
