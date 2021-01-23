    System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
    byte[] key = new byte[20];
        
    rng.GetBytes(key);
    string secretKey = key.ToBase64()
