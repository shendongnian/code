    MemoryStream textBytes = new MemoryStream();
    
    string password = @"myKey123"; // Your Key Here
    
    UnicodeEncoding UE = new UnicodeEncoding();
    byte[] key = UE.GetBytes(password);
    
    FileStream fsInput = new FileStream(@"C:\myEncryptFile.txt", FileMode.Open);
    
    RijndaelManaged RMCrypto = new RijndaelManaged();
    
    CryptoStream cs = new CryptoStream(fsInput, RMCrypto.CreateDecryptor(key, key),
                                        CryptoStreamMode.Read);
    cs.CopyTo(textBytes);
    
    cs.Close();
    fsInput.Close();
    
    string myDecriptText = Encoding.UTF8.GetString(textBytes.ToArray());
