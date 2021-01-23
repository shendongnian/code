            byte[] key = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            byte[] iv = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            byte[] data = { 1, 2, 3, 4, 5 };   
            using (var symmetrickey = Rijndael.Create().CreateEncryptor(key, iv))
            {
                using (Stream f = File.Create("anencryptedfile.bin"))
                {
                    using (Stream c = new CryptoStream(f, symmetrickey, CryptoStreamMode.Write))
                    {
                        c.Write(data, 0, data.Length);
                    }
                }
            }
