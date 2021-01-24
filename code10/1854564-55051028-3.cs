    public static string EncryptData(string data)
    {
        var certificate = GetCertificate();
    
        using (RSA rsa = certificate.GetRSAPublicKey())
        {
            var dataBytes = Convert.FromBase64String(data);
            var encryptedBytes = rsa.Encrypt(dataBytes, RSAEncryptionPadding.Pkcs1);
    
            return Convert.ToBase64String(encryptedBytes);
        }
    }
