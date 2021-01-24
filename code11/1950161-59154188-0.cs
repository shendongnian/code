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
