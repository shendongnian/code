        private static string _encrypt(string value, string key, string initVector)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(value);
            byte[] encBuffer;
            using (System.Security.Cryptography.RijndaelManaged rmt = new System.Security.Cryptography.RijndaelManaged())
            {
                rmt.KeySize = 256;
                rmt.BlockSize = 128;
                rmt.Mode = System.Security.Cryptography.CipherMode.CBC;
                rmt.Padding = System.Security.Cryptography.PaddingMode.ISO10126;
                encBuffer = rmt.CreateEncryptor(Convert.FromBase64String(key),
                    Convert.FromBase64String(initVector)).TransformFinalBlock(buffer, 0, buffer.Length);
            }
            string encryptValue = ConvertToHex(encBuffer);
            return encryptValue;
        }
        private static string _decrypt(string key, string initVector, string value)
        {
            byte[] hexBuffer = HexString2ByteArray(value);
            byte[] decBuffer;
            using (System.Security.Cryptography.RijndaelManaged rmt = new System.Security.Cryptography.RijndaelManaged())
            {
                rmt.KeySize = 256;
                rmt.BlockSize = 128;
                rmt.Mode = System.Security.Cryptography.CipherMode.CBC;
                rmt.Padding = System.Security.Cryptography.PaddingMode.ISO10126;
                decBuffer = rmt.CreateDecryptor(Convert.FromBase64String(key),
                    Convert.FromBase64String(initVector)).TransformFinalBlock(hexBuffer, 0, hexBuffer.Length);
            }
            return Encoding.Unicode.GetString(decBuffer);
        } 
