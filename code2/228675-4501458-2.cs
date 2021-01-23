        private static void EncryptThenDecrypt()
        {
            byte[] message; // fill with your bytes
            byte[] encMessage; // the encrypted bytes
            byte[] decMessage; // the decrypted bytes - s/b same as message
            byte[] key;
            byte[] iv;
            using (var rijndael = new RijndaelManaged())
            {
                rijndael.GenerateKey();
                rijndael.GenerateIV();
                key = rijndael.Key;
                iv = rijndael.IV;
                encMessage = EncryptBytes(rijndael, message);
            }
            using (var rijndael = new RijndaelManaged())
            {
                rijndael.Key = key;
                rijndael.IV = iv;
                decMessage = DecryptBytes(rijndael, encMessage);
            }
        }
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
        private static byte[] DecryptBytes(
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
            using (var decryptor = alg.CreateDecryptor())
            using (var encrypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Write))
            {
                encrypt.Write(message, 0, message.Length);
                encrypt.FlushFinalBlock();
                return stream.ToArray();
            }
        }
