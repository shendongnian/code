    public static void Main(string[] args)
    {
        var algorithm = new RijndaelManaged()
        {
            Mode = CipherMode.CFB,
            // This is the equivalent of BlockSize in CFB mode. We set it to 8 (bits) to prevent any buffering of data 
            // while waiting for whole blocks.
            FeedbackSize = 8,
        };
        // Don't hard-code in real life, obviously
        var key = new byte[32];
        var iv = new byte[16];
        var input = new byte[] { 1, 2, 3 };
        byte[] result;
        using (var ms = new MemoryStream())
        {
            using (var cryptoStream = new CryptoStream(ms, algorithm.CreateEncryptor(key, iv), CryptoStreamMode.Write))
            {
                cryptoStream.Write(input, 0, input.Length);
            }
            result = ms.ToArray();
        }
    }
