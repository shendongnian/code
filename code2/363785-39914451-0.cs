    public static string EncryptVNC(string password)
        {
            if (password.Length > 8)
            {
                password = password.Substring(0, 8);
            }
            if (password.Length < 8)
            {
                password = password.PadRight(8, '\0');
            }
            byte[] key = { 23, 82, 107, 6, 35, 78, 88, 7 };
            byte[] passArr = new ASCIIEncoding().GetBytes(password);
            byte[] response = new byte[passArr.Length];
            char[] chars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            // reverse the byte order
            byte[] newkey = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                // revert desKey[i]:
                newkey[i] = (byte)(
                    ((key[i] & 0x01) << 7) |
                    ((key[i] & 0x02) << 5) |
                    ((key[i] & 0x04) << 3) |
                    ((key[i] & 0x08) << 1) |
                    ((key[i] & 0x10) >> 1) |
                    ((key[i] & 0x20) >> 3) |
                    ((key[i] & 0x40) >> 5) |
                    ((key[i] & 0x80) >> 7)
                    );
            }
            key = newkey;
            // reverse the byte order
            DES des = new DESCryptoServiceProvider();
            des.Padding = PaddingMode.None;
            des.Mode = CipherMode.ECB;
            ICryptoTransform enc = des.CreateEncryptor(key, null);
            enc.TransformBlock(passArr, 0, passArr.Length, response, 0);
            string hexString = String.Empty;
            for (int i = 0; i < response.Length; i++)
            {
                hexString += chars[response[i] >> 4];
                hexString += chars[response[i] & 0xf];
            }
            return hexString.Trim().ToLower();
        }
