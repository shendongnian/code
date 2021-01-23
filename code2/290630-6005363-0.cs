    private static byte[] Key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 222, 209, 241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 53, 209 };
    private static byte[] Vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 221, 112, 79, 32, 114, 156 };
    
    private static RijndaelManaged _rijndaelManaged;
    
    static void Main(string[] args)
    {
        var allBytes = File.ReadAllBytes("hello.bin");
        _rijndaelManaged = new RijndaelManaged { Key = Key, IV = Vector };
    
        byte[] encBytes = Encrypt(allBytes, Key, Vector);
    
        byte[] decBytes = Decrypt(encBytes, Key, Vector);
        
        using (var mstream = new MemoryStream(decBytes))
        using (var breader = new BinaryReader(mstream))
        {
            Console.WriteLine(breader.ReadString());
        }
    }
    
    private static byte[] Decrypt(byte[] encBytes, byte[] key, byte[] vector)
    {
        byte[] decBytes;
    
        using (var mstream = new MemoryStream())
        using (var crypto = new CryptoStream(mstream, _rijndaelManaged.CreateDecryptor(key, vector), CryptoStreamMode.Write))
        {
            crypto.Write(encBytes, 0, encBytes.Length);
            crypto.FlushFinalBlock();
    
            mstream.Position = 0;
    
            decBytes = new byte[mstream.Length];
            mstream.Read(decBytes, 0, decBytes.Length);
        }
    
        return decBytes;
    }
    
    private static byte[] Encrypt(byte[] allBytes, byte[] key, byte[] vector)
    {
        byte[] encBytes;
    
        using (var mstream = new MemoryStream())
        using (var crypto = new CryptoStream(mstream, _rijndaelManaged.CreateEncryptor(key, vector), CryptoStreamMode.Write))
        {
            crypto.Write(allBytes, 0, allBytes.Length);
            crypto.FlushFinalBlock();
    
            mstream.Position = 0;
    
            encBytes = new byte[mstream.Length];
            mstream.Read(encBytes, 0, encBytes.Length);
        }
    
        return encBytes;
    }
