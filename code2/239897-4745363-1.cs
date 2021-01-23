    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
    byte[] Key = { 12, 13, 14, 15, 16, 17, 18, 19 };
    byte[] IV =  { 12, 13, 14, 15, 16, 17, 18, 19 };
    
    ICryptoTransform encryptor = des.CreateEncryptor(Key, IV);
    
    byte[] IDToBytes = ASCIIEncoding.ASCII.GetBytes(source);
    byte[] encryptedID = encryptor.TransformFinalBlock(IDToBytes, 0, IDToBytes.Length);
    return Convert.ToBase64String(encryptedID);
