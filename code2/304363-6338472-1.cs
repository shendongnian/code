        public byte[] GenerateSalt(int length)
        {
            salt = new byte[length];
            // Strong runtime pseudo-random number generator, on Windows uses CryptAPI
            // on Unix /dev/urandom
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            random.GetNonZeroBytes(salt);
            return salt;
        }
