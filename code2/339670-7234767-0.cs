        public static byte[] AsymmetricEncrypt(string publicKeyAsPem, byte[] payload)
        {
            CryptoKey d = CryptoKey.FromPublicKey(publicKeyAsPem, null);
            RSA rsa = d.GetRSA();
            byte[] result = rsa.PublicEncrypt(payload, RSA.Padding.PKCS1);
            rsa.Dispose();
            return result;
        }
        public static byte[] AsymmetricDecrypt(string privateKeyAsPem, byte[] payload)
        {
            CryptoKey d = CryptoKey.FromPrivateKey(privateKeyAsPem, null);
            RSA rsa = d.GetRSA();
            byte[] result = rsa.PrivateDecrypt(payload, RSA.Padding.PKCS1);
            rsa.Dispose();
            return result;
        }
