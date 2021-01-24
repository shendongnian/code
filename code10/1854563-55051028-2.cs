    public static string EncryptData(string data)
    {
        var certificate = GetCertificate();
    
        using (var rsa = certificate.PublicKey.Key as RSACryptoServiceProvider)
        {
            var dataBytes = Convert.FromBase64String(data);
            var encryptedBytes = rsa.Encrypt(dataBytes, false);
    
            return Convert.ToBase64String(encryptedBytes);
        }
    }
