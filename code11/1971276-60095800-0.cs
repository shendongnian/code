    static void hash_mac()
            {
                message = "123456";
                using (var hmacsha256 = new System.Security.Cryptography.HMACSHA1(StringToByteArray("246439589af7f1d84eb638c995687d53")))
                {
                    hmacsha256.ComputeHash(encoding.GetBytes(message));
    
                    Console.WriteLine("Result: {0}", ByteToString(hmacsha256.Hash));
                }
            }
    
    
            public static byte[] StringToByteArray(String hex)
            {
                int NumberChars = hex.Length;
                byte[] bytes = new byte[NumberChars / 2];
                for (int i = 0; i < NumberChars; i += 2)
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                return bytes;
            }
