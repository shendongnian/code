    private static byte[] Decrypt(byte[] payLoad, string privateKey)
    {
        using (var key = OpenSSL.Crypto.CryptoKey.FromPrivateKey(privateKey, null))
        {
            using (var rsa = key.GetRSA())
            {
                return rsa.PrivateDecrypt(payLoad, OpenSSL.Crypto.RSA.Padding.PKCS1);
            }
        }
    }
