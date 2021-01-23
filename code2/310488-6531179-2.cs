    public static void Main()
    {
        using (var rijndael = InitSymmetric(Rijndael.Create(), "TestPassword", 256))
        {
            var text = "Some text to encrypt";
            var bytes = Encoding.UTF8.GetBytes(text);
            var encryptedBytes = Transform(bytes, rijndael.CreateEncryptor);
            var decryptedBytes = Transform(encryptedBytes, rijndael.CreateDecryptor);
            var decryptedText = Encoding.UTF8.GetString(decryptedBytes);
            Debug.Assert(text == decryptedText);
        }
    }
    private static byte[] Transform(byte[] bytes, Func<ICryptoTransform> selectCryptoTransform)
    {
        using (var memoryStream = new MemoryStream())
        {
            using (var cryptoStream = new CryptoStream(memoryStream, selectCryptoTransform(), CryptoStreamMode.Write))
                cryptoStream.Write(bytes, 0, bytes.Length);
            return memoryStream.ToArray();
        }
    }
    public static SymmetricAlgorithm InitSymmetric(SymmetricAlgorithm algorithm, string password, int keyBitLength)
    {
        var salt = new byte[] { 1, 2, 23, 234, 37, 48, 134, 63, 248, 4 };
        const int Iterations = 234;
        using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations))
        {
            if (!algorithm.ValidKeySize(keyBitLength))
                throw new InvalidOperationException("Invalid size key");
            algorithm.Key = rfc2898DeriveBytes.GetBytes(keyBitLength / 8);
            algorithm.IV = rfc2898DeriveBytes.GetBytes(algorithm.BlockSize / 8);
            return algorithm;
        }
    }
