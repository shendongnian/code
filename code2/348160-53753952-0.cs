        public byte[] GetSignature(byte[] inputData)
        {
            using (var rsa = this.signingCertificate.GetRSAPrivateKey())
            {
                return rsa.SignData(inputData, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
        }
        public bool ValidateSignature(byte[] inputData, byte[] signature)
        {
            using (var rsa = this.signingCertificate.GetRSAPublicKey())
            {
                return rsa.VerifyData(inputData, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
        }
