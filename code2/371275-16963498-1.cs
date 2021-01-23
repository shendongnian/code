    public static string DecryptString(byte[] encryptedString, byte[] encryptionKey)
    {
        using (var provider = new AesCryptoServiceProvider())
        {
            provider.Key = encryptionKey;
            using (var ms = new MemoryStream(encryptedString))
            {
                // Read the first 16 bytes which is the IV.
                byte[] iv = new byte[16];
                ms.Read(iv, 0, 16);
                provider.IV = iv;
                using (var decryptor = provider.CreateDecryptor())
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
