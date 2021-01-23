    string text = "Hello";
    using (var aes = new AesManaged())
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] encryptedBytes;
        using (var encrypt = aes.CreateEncryptor())
        {
            encryptedBytes = encrypt.TransformFinalBlock(bytes, 0, bytes.Length);
        }
        byte[] decryptedBytes;
        using (var decrypt = aes.CreateDecryptor())
        {
            decryptedBytes = decrypt.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
        }
        var decryptedText = System.Text.Encoding.UTF8.GetString(decryptedBytes);
        Console.Out.WriteLine("decryptedText = {0}", decryptedText);
    }
