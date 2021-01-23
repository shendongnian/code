    // create and initialize a crypto algorithm
    private static SymmetricAlgorithm getAlgorithm(string password) {
        SymmetricAlgorithm algorithm = Rijndael.Create();
        Rfc2898DeriveBytes rdb = new Rfc2898DeriveBytes(
            password, new byte[] {
            0x53,0x6f,0x64,0x69,0x75,0x6d,0x20,             // salty goodness
            0x43,0x68,0x6c,0x6f,0x72,0x69,0x64,0x65
        }
        );
        algorithm.Padding = PaddingMode.ISO10126;
        algorithm.Key = rdb.GetBytes(32);
        algorithm.IV = rdb.GetBytes(16);
        return algorithm;
    }
    /* 
     * encryptString
     * provides simple encryption of a string, with a given password
     */
    public static string EncryptString(string clearText, string password) {
        SymmetricAlgorithm algorithm = getAlgorithm(password);
        byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, algorithm.CreateEncryptor(), CryptoStreamMode.Write);
        cs.Write(clearBytes, 0, clearBytes.Length);
        cs.Close();
        return Convert.ToBase64String(ms.ToArray());
    }
    /*
     * decryptString
     * provides simple decryption of a string, with a given password
     */
    public static string DecryptString(string cipherText, string password) {
        SymmetricAlgorithm algorithm = getAlgorithm(password);
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, algorithm.CreateDecryptor(), CryptoStreamMode.Write);
        cs.Write(cipherBytes, 0, cipherBytes.Length);
        cs.Close();            
        return System.Text.Encoding.Unicode.GetString(ms.ToArray());
    }
