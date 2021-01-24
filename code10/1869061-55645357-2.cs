    public static void Main(string[] args)
    {
        string plainText = "Here is somewe data to encrypt!";
    
        using (Aes myAes = Aes.Create())
        {
            byte[] cipherText = Encrypt(plainText, myAes.Key, myAes.IV);
            plainText = Decrypt(cipherText, myAes.Key, myAes.IV);
    
            Console.WriteLine(plainText);
        }
    }
    
    public static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
    {
        byte[] encrypted;
        // Create a new AesManaged.    
        using (AesManaged aes = new AesManaged())
        {
            // Create encryptor    
            ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
            // Create MemoryStream    
            using (MemoryStream ms = new MemoryStream())
            {
                // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                // to encrypt    
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    // Create StreamWriter and write data to a stream    
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        //Write all data to the stream.
                        sw.Write(plainText);
                    }
                    encrypted = ms.ToArray();    
                }                    
            }
        }
        // Return the encrypted bytes from the memory stream.
        return encrypted;
    }
    
    public static string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
    {
        string plaintext = string.Empty;
        // Create AesManaged    
        using (AesManaged aes = new AesManaged())
        {
            // Create a decryptor    
            ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
            // Create the streams used for decryption.    
            using (MemoryStream ms = new MemoryStream(cipherText))
            {
                // Create crypto stream    
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    // Read crypto stream 
                    using (StreamReader reader = new StreamReader(cs))
                    {
                        plaintext = reader.ReadToEnd();
                    }
                }
            }
        }
        return plaintext;
    }
    
