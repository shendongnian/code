    public static string DecryptString(this string text, string passPhrase)
    {
        string result = null;
        if ( !String.IsNullOrEmpty ( text ) )
        {
            byte [] initVectorBytes = Encoding.UTF8.GetBytes ( m_InitVector );
            byte [] cipherTextBytes = Convert.FromBase64String ( text );
            PasswordDeriveBytes password = new PasswordDeriveBytes ( passPhrase, null );
            byte [] keyBytes = password.GetBytes ( m_Keysize / 8 );
            RijndaelManaged symmetricKey = new RijndaelManaged ();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor ( keyBytes, initVectorBytes );
            MemoryStream memoryStream = new MemoryStream ( cipherTextBytes );
            CryptoStream cryptoStream = new CryptoStream ( memoryStream, decryptor, CryptoStreamMode.Read );
            byte [] plainTextBytes = new byte [cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read ( plainTextBytes, 0, plainTextBytes.Length );
            memoryStream.Close ();
            cryptoStream.Close ();
            result = Encoding.UTF8.GetString ( plainTextBytes, 0, decryptedByteCount );
        }
        return result;
    }
