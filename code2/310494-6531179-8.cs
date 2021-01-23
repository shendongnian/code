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
