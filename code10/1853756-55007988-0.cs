    public static string EncryptString(this string text, string passPhrase)
    {
        string result = null;
        if(!String.IsNullOrEmpty(text))
        {
            byte [] initVectorBytes = Encoding.UTF8.GetBytes ( m_InitVector );
            byte [] plainTextBytes = Encoding.UTF8.GetBytes ( text );
            PasswordDeriveBytes password = new PasswordDeriveBytes ( passPhrase, null );
            byte [] keyBytes = password.GetBytes ( m_Keysize / 8 );
            RijndaelManaged symmetricKey = new RijndaelManaged ();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor ( keyBytes, initVectorBytes );
            MemoryStream memoryStream = new MemoryStream ();
            CryptoStream cryptoStream = new CryptoStream ( memoryStream, encryptor,  CryptoStreamMode.Write );
            cryptoStream.Write ( plainTextBytes, 0, plainTextBytes.Length );
            cryptoStream.FlushFinalBlock ();
            byte [] cipherTextBytes = memoryStream.ToArray ();
            memoryStream.Close ();
            cryptoStream.Close ();
            result = Convert.ToBase64String ( cipherTextBytes );
        }
        return result;
    }
