        public static string Decrypt(string cypherString)
        {
            byte[] key = Encoding.ASCII.GetBytes("icatalogDR0wSS@P6660juht");
            byte[] iv = Encoding.ASCII.GetBytes("iCatalog");
            byte[] data = Convert.FromBase64String(cypherString);
            byte[] enc = new byte[0];
            TripleDES tdes = TripleDES.Create();
            tdes.IV = iv;
            tdes.Key = key;
            tdes.Mode = CipherMode.CBC;
            tdes.Padding = PaddingMode.Zeros;
            ICryptoTransform ict = tdes.CreateDecryptor();
            enc = ict.TransformFinalBlock(data, 0, data.Length);
            return UTF8Encoding.UTF8.GetString(enc, 0, enc.Length);
        }
