    public string DecryptUsingPublic(string dataEncryptedBase64, string publicKey)
        {
            if (dataEncryptedBase64 == null) throw new ArgumentNullException("dataEncryptedBase64");
            if (publicKey == null) throw new ArgumentNullException("publicKey");
            try
            {
                RSAParameters _publicKey = LoadRsaPublicKey(publicKey, false);
                RSACryptoServiceProvider rsa = InitRSAProvider(_publicKey);
                byte[] bytes = Convert.FromBase64String(dataEncryptedBase64);
                byte[] decryptedBytes = rsa.Decrypt(bytes, false);
                // I assume here that the decrypted data is intended to be a
                // human-readable string, and that it was UTF8 encoded.
                return Encoding.UTF8.GetString(decryptedBytes);
            }
            catch
            {
                return null;
            }
        }
