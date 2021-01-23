        private static byte[] EncryptBytes(
            SymmetricAlgorithm alg,
            byte[] message)
        {
            if ((message == null) || (message.Length == 0))
            {
                return message;
            }
            if (alg == null)
            {
                throw new ArgumentNullException("alg");
            }
            using (var stream = new MemoryStream())
            using (var encryptor = alg.CreateEncryptor())
            using (var encrypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
            {
                encrypt.Write(message, 0, message.Length);
                encrypt.FlushFinalBlock();
                return stream.ToArray();
            }
        }
