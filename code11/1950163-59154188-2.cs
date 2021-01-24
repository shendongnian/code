public static string AesEncrypt(string plainText, byte[] Key, byte[] IV)
{
     // Create an Aes object with the specified key and IV
     using Aes aesAlg = Aes.Create();
     aesAlg.Key = Key;
     aesAlg.IV = IV;
     ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
     using MemoryStream msEncrypt = new MemoryStream();
     using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
     using StreamWriter swEncrypt = new StreamWriter(csEncrypt);
     swEncrypt.Write(plainText);
     //CHANGES HERE
     swEncrypt.Flush();
     return Convert.ToBase64String(msEncrypt.ToArray());
}
The sample doesn't suffer from this problem because it uses explicit `using` blocks, so the writer is closed *before* the memory stream is used :
    using (MemoryStream msEncrypt = new MemoryStream())
    {
        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        {
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(plainText);
            }
            encrypted = msEncrypt.ToArray();
        }
    }
Neither Visual Studio nor Resharper would suggest using a `using` statement in this case, as the `writer` is clearly closed in the innermost block.
**Don't mix `using` styles**
You can mix using blocks and statements, eg :
    using MemoryStream msEncrypt = new MemoryStream();
    using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
    {
        swEncrypt.Write(plainText);
    }
    encrypted = msEncrypt.ToArray();
Given the confusion caused already though, you probably shouldn't. The code isn't that much cleaner and it already caused a problem. Someone else looking at the same code in the future may get confused as well and use a bad refactoring
