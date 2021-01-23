    /// <summary>
    /// Create and initialize a crypto algorithm.
    /// </summary>
    /// <param name="password">The password.</param>
    private static SymmetricAlgorithm GetAlgorithm(string password)
    {
        var algorithm = Rijndael.Create();
        var rdb = new Rfc2898DeriveBytes(password, new byte[] {
            0x53,0x6f,0x64,0x69,0x75,0x6d,0x20,             // salty goodness
            0x43,0x68,0x6c,0x6f,0x72,0x69,0x64,0x65
        });
        algorithm.Padding = PaddingMode.ISO10126;
        algorithm.Key = rdb.GetBytes(32);
        algorithm.IV = rdb.GetBytes(16);
        return algorithm;
    }
    /// <summary>
    /// Encrypts a string with a given password.
    /// </summary>
    /// <param name="clearText">The clear text.</param>
    /// <param name="password">The password.</param>
    public static string EncryptString(string clearText, string password)
    {
        var algorithm = GetAlgorithm(password);
        var encryptor = algorithm.CreateEncryptor();
        var clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (var ms = new MemoryStream())
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        {
            cs.Write(clearBytes, 0, clearBytes.Length);
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }
    }
    /// <summary>
    /// Decrypts a string using a given password.
    /// </summary>
    /// <param name="cipherText">The cipher text.</param>
    /// <param name="password">The password.</param>
    public static string DecryptString(string cipherText, string password)
    {
        var algorithm = GetAlgorithm(password);
        var decryptor = algorithm.CreateDecryptor();
        var cipherBytes = Convert.FromBase64String(cipherText);
        using (var ms = new MemoryStream())
        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
        {
            cs.Write(cipherBytes, 0, cipherBytes.Length);
            cs.Close();
            return Encoding.Unicode.GetString(ms.ToArray());
        }
    }
