    protected void Page_Load(object sender, EventArgs e)
    {
        string value = "";
        string password = "";
        string salt = "";
        string iv = "";
        byte[] vectorBytes = Convert.FromBase64String(Server.UrlDecode(iv)); 
        byte[] cipherText = Convert.FromBase64String(Server.UrlDecode(value));
        Rfc2898DeriveBytes key1 = new Rfc2898DeriveBytes(password, StringToByteArray(salt)); //same as PBKDF2WithHmacSHA1
        key1.IterationCount = 32;
        byte[] keyBytes = key1.GetBytes(16);
        string Answer = DecryptDataAES(cipherText, keyBytes, vectorBytes); //vectorBytes is good
        //litAnswer.Text = Answer;
    }
    public static string DecryptDataAES(byte[] cipherText, byte[] key, byte[] iv)
    {
        string plaintext = null;
        using (Rijndael rijndael = Rijndael.Create())
        {
            rijndael.Key = key;
            rijndael.IV = iv;
            rijndael.Padding = PaddingMode.None;
            ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);
            // Create the streams used for decryption. 
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }
        return plaintext;
    }
    public static byte[] StringToByteArray(String hex)
    {
        int NumberChars = hex.Length / 2;
        byte[] bytes = new byte[NumberChars];
        using (var sr = new StringReader(hex))
        {
            for (int i = 0; i < NumberChars; i++)
                bytes[i] =
                  Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
        }
        return bytes;
    }
