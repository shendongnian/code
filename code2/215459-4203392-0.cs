        public static string Decrypt(string stringToDecrypt)
        {
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = byteConverter.GetBytes(stringToDecrypt);
            byte[] decryptedData = null;
            try
            {
                using (RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider())
                {
                    rsaCryptoServiceProvider.FromXmlString(_key);
                    byte[] decryptBytes = Encoding.Default.GetBytes(Properties.Settings.Default.SqlPassword);
                    decryptedData = rsaCryptoServiceProvider.Decrypt(decryptBytes, false);
                }
            }
            catch (Exception ex)
            {
                //TODO Do proper logging
                Console.WriteLine("Decrypt failed: " + ex.Message);
            }
            return byteConverter.GetString(decryptedData);
        }
        public static string Encrypt(string stringToEncrypt)
        {
            try
            {
                UnicodeEncoding byteConverter = new UnicodeEncoding();
                byte[] dataToEncrypt = byteConverter.GetBytes(stringToEncrypt);
                using (RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider())
                {
                    rsaCryptoServiceProvider.FromXmlString(_key);
                    byte[] encryptedData = rsaCryptoServiceProvider.Encrypt(dataToEncrypt, false);
                    return Encoding.Default.GetString(encryptedData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Encrypt failed: " + ex.Message);
            }
        }
