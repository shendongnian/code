 public static string encryptionMethod(string Text, string key)
        {
            string encryptedText = string.Empty;
            try
            {
                byte[] clearBytes = StringToByteArray(Text); ;//Encoding.UTF8.GetBytes(Text);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                des.KeySize = 128;
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.None;
                des.Key = StringToByteArray(key);   //Passing key in byte array
                //des.BlockSize = 64;
                byte[] ivBytes = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                des.IV = ivBytes;
                ICryptoTransform ct = des.CreateEncryptor();   //Interface with some result
                byte[] resultArray = ct.TransformFinalBlock(clearBytes, 0, clearBytes.Length);
                encryptedText = ByteArrayToHexString(resultArray);
            }
            catch (Exception exception)
            {
                return "";
            }
            return encryptedText;
        }
  public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
