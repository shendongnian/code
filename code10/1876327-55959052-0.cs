        private const short CKEY1 = 11111;
        private const short CKEY2 = 22222;
        public static string EncryptAString(string s, ushort Key)
        {
            try
            {
                var encryptedValue = string.Empty;
                // Create a UTF-8 encoding.
                UTF8Encoding utf8 = new UTF8Encoding();
                // Encode the string.
                byte[] RStrB = utf8.GetBytes(s);
                for (var i = 0; i <= RStrB.Length - 1; i++)
                {
                    RStrB[i] = Convert.ToByte(RStrB[i] ^ (Key >> 8));
                    Key = (ushort)(((RStrB[i] + Key) * CKEY1) + CKEY2);
                }
                for (var i = 0; i <= RStrB.Length - 1; i++)
                {
                    encryptedValue = encryptedValue + RStrB[i].ToString("X2");
                }
                return encryptedValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
