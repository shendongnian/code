    private static string EncryptRsa(byte[] input)
    {
        string output = string.Empty;
        System.Security.Cryptography.X509Certificates.X509Certificate2 cert = new X509Certificate2(@"Cert/server_pub.cer");
    
    
        using (RSA csp = (RSA)cert.PublicKey.Key)
                    {
                        byte[] bytesData = input;
                        byte[] bytesEncrypted = csp.Encrypt(bytesData, RSAEncryptionPadding.OaepSHA1);
                        output = Convert.ToBase64String(bytesEncrypted);
                    }
        return output;
    }
