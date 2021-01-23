    byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8 }; // Where to store these keys is the tricky part, 
        // you may need to obfuscate them or get the user to input a password each time
    byte[] iv = { 1, 2, 3, 4, 5, 6, 7, 8 };
    string path = @"C:\path\to.file";
    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
    // Encryption
    using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
    using (var cryptoStream = new CryptoStream(fs, des.CreateEncryptor(key, iv), CryptoStreamMode.Write))
    {
        BinaryFormatter formatter = new BinaryFormatter();
        // This is where you serialize the class
        formatter.Serialize(cryptoStream, customClass);
    }
    // Decryption
    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
    using (var cryptoStream = new CryptoStream(fs, des.CreateDecryptor(key, iv), CryptoStreamMode.Read))
    {
        BinaryFormatter formatter = new BinaryFormatter();
        // This is where you deserialize the class
        CustomClass deserialized = (CustomClass)formatter.Deserialize(cryptoStream);
    }
