        using (var msEncrypt = new MemoryStream())
        {
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(baseString);
                }
                var encryptedBytes = msEncrypt.ToArray();
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(Convert.ToBase64String(encryptedBytes)));
            }
        }
