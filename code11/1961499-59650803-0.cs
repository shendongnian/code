    private static string Encrypt(string content, string password)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(content);
    
        using (SymmetricAlgorithm crypt = Aes.Create())
        using (HashAlgorithm hash = MD5.Create())
        using (MemoryStream memoryStream = new MemoryStream())
        {
            alg.Key = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            // This is really only needed before you call CreateEncryptor the second time,
            // since it starts out random.  But it's here just to show it exists.
            alg.GenerateIV();
        
            using (CryptoStream cryptoStream = new CryptoStream(
                memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(bytes, 0, bytes.Length);
            }
        
            string base64IV = Convert.ToBase64String(crypt.IV);
            string base64Ciphertext = Convert.ToBase64String(memoryStream.ToArray());
    
            return base64IV + "!" + base64Ciphertext;
        }
    }
