    namespace Power.Storage.Helpers
    {
    public class SimplerAES
    {
    private static byte[] key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 222, 209, 241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 53, 209 };
    private static byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 221, 112, 79, 32, 114, 156 };
    private static RijndaelManaged rm = new RijndaelManaged();
    public byte[] Encrypt(byte[] buffer)
    {
    MemoryStream encryptStream = new MemoryStream();
    ICryptoTransform encryptor = rm.CreateEncryptor(key, vector);
    using (CryptoStream cs = new CryptoStream(encryptStream, encryptor, CryptoStreamMode.Write))
    {
    cs.Write(buffer, 0, buffer.Length);
    }
    return encryptStream.ToArray();
    }
    public byte[] Decrypt(byte[] buffer)
    {
    MemoryStream decryptStream = new MemoryStream();
    ICryptoTransform decryptor = rm.CreateDecryptor(key, vector);
    using (CryptoStream cs = new CryptoStream(decryptStream, decryptor, CryptoStreamMode.Write))
    {
    cs.Write(buffer, 0, buffer.Length);
    }
    return decryptStream.ToArray();
    }
    }
    }
