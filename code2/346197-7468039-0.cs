        try
        {
            // Create a new instance of the AesManaged class.  This generates a new key and initialization vector (IV).
            AesManaged myAes = new AesManaged();
            // Override the cipher mode, key and IV
            myAes.Mode = CipherMode.ECB;
            myAes.IV = new byte[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // CRB mode uses an empty IV
            myAes.Key = CipherKey;  // Byte array representing the key
            myAes.Padding = PaddingMode.None;
            // Create a encryption object to perform the stream transform.
            ICryptoTransform encryptor = myAes.CreateEncryptor();
            // TODO: perform the encryption / decryption as required...
        }
        catch (Exception ex)
        {
            // TODO: Log the error 
            throw ex;
        }
