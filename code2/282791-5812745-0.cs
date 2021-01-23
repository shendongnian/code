        static void Main()
        {
            byte[] test = Encrypt(Encoding.UTF8.GetBytes("Hello World!"), "My Product Name and/or whatever constant", "password");
            Console.WriteLine(Convert.ToBase64String(test));
            string plain = Encoding.UTF8.GetString(Decrypt(test, "My Product Name and/or whatever constant", "passwords"));
            Console.WriteLine(plain);
        }
        public static byte[] Encrypt(byte[] data, string iv, string password)
        {
            using (RijndaelManaged m = new RijndaelManaged())
            using (SHA256Managed h = new SHA256Managed())
            {
                m.KeySize = 256;
                m.BlockSize = 256;
                byte[] hash = h.ComputeHash(data);
                byte[] salt = new byte[32];
                new RNGCryptoServiceProvider().GetBytes(salt);
                m.IV = h.ComputeHash(Encoding.UTF8.GetBytes(iv));
                m.Key = new Rfc2898DeriveBytes(password, salt) { IterationCount = 10000 }.GetBytes(32);
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(hash, 0, hash.Length);
                    ms.Write(salt, 0, salt.Length);
                    using (CryptoStream cs = new CryptoStream(ms, m.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.FlushFinalBlock();
                        return ms.ToArray();
                    }
                }
            }
        }
        public static byte[] Decrypt(byte[] data, string iv, string password)
        {
            using (MemoryStream ms = new MemoryStream(data, false))
            using (RijndaelManaged m = new RijndaelManaged())
            using (SHA256Managed h = new SHA256Managed())
            {
                try
                {
                    m.KeySize = 256;
                    m.BlockSize = 256;
                    byte[] hash = new byte[32];
                    ms.Read(hash, 0, 32);
                    byte[] salt = new byte[32];
                    ms.Read(salt, 0, 32);
                    m.IV = h.ComputeHash(Encoding.UTF8.GetBytes(iv));
                    m.Key = new Rfc2898DeriveBytes(password, salt) { IterationCount = 10000 }.GetBytes(32);
                    using (MemoryStream result = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, m.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            byte[] buffer = new byte[1024];
                            int len;
                            while ((len = cs.Read(buffer, 0, buffer.Length)) > 0)
                                result.Write(buffer, 0, len);
                        }
                        byte[] final = result.ToArray();
                        if (Convert.ToBase64String(hash) != Convert.ToBase64String(h.ComputeHash(final)))
                            throw new UnauthorizedAccessException();
                        return final;
                    }
                }
                catch
                {
                    //never leak the exception type...
                    throw new UnauthorizedAccessException();
                }
            }
        }
