    // This already returns a string... you don't need to call ToString() on it
    string encryptedTime = Request.QueryString["Time"];
    // We don't know what "com" is here...
    string key = com.KeyCode.ToString();
    string decryptedTime = com.Decrypt(encryptedTime, key);
    DateTime mydt = Convert.ToDateTime(decryptedTime);
