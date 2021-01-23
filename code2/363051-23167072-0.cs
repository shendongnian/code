        private byte[] TDES_Key = { 0x01, 0x04, 0x01, 0x01, 0x01, 0x09, 0x07, 0x08, 0x01, 0x09, 0x07, 0x08, 0x01, 0x01, 0x02, 0x04 };
        private byte[] tdesIV;
        public string Encrypt(string textToEncrypt,string KeyVI)
        {
            tdesIV = GetLegalKey(KeyVI);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = TDES_Key;
            tdes.IV = tdesIV;
            byte[] buffer = Encoding.ASCII.GetBytes(textToEncrypt); 
            return Convert.ToBase64String(tdes.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));/// 
        }   
