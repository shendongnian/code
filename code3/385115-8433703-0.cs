        public static string Encrypt(string dataToEncrypt, RSAParameters publicKeyInfo)
        {
            //// Our bytearray to hold all of our data after the encryption
            byte[] encryptedBytes = new byte[0];
            using (var RSA = new RSACryptoServiceProvider())
            {
                try
                {
                    //Create a new instance of RSACryptoServiceProvider.
                    UTF8Encoding encoder = new UTF8Encoding();
                    byte[] encryptThis = encoder.GetBytes(dataToEncrypt);
                    //// Importing the public key
                    RSA.ImportParameters(publicKeyInfo);
                    int blockSize = (RSA.KeySize / 8) - 32;
                    //// buffer to write byte sequence of the given block_size
                    byte[] buffer = new byte[blockSize];
                    byte[] encryptedBuffer = new byte[blockSize];
                    //// Initializing our encryptedBytes array to a suitable size, depending on the size of data to be encrypted
                    encryptedBytes = new byte[encryptThis.Length + blockSize - (encryptThis.Length % blockSize) + 32];
                    for (int i = 0; i < encryptThis.Length; i += blockSize)
                    {
                        //// If there is extra info to be parsed, but not enough to fill out a complete bytearray, fit array for last bit of data
                        if (2 * i > encryptThis.Length && ((encryptThis.Length - i) % blockSize != 0))
                        {
                            buffer = new byte[encryptThis.Length - i];
                            blockSize = encryptThis.Length - i;
                        }
                        //// If the amount of bytes we need to decrypt isn't enough to fill out a block, only decrypt part of it
                        if (encryptThis.Length < blockSize)
                        {
                            buffer = new byte[encryptThis.Length];
                            blockSize = encryptThis.Length;
                        }
                        //// encrypt the specified size of data, then add to final array.
                        Buffer.BlockCopy(encryptThis, i, buffer, 0, blockSize);
                        encryptedBuffer = RSA.Encrypt(buffer, false);
                        encryptedBuffer.CopyTo(encryptedBytes, i);
                    }
                }
                catch (CryptographicException e)
                {
                    Console.Write(e);
                }
                finally
                {
                    //// Clear the RSA key container, deleting generated keys.
                    RSA.PersistKeyInCsp = false;
                }
            }
            //// Convert the byteArray using Base64 and returns as an encrypted string
            return Convert.ToBase64String(encryptedBytes);
        }
        /// <summary>
        /// Decrypt this message using this key
        /// </summary>
        /// <param name="dataToDecrypt">
        /// The data To decrypt.
        /// </param>
        /// <param name="privateKeyInfo">
        /// The private Key Info.
        /// </param>
        /// <returns>
        /// The decrypted data.
        /// </returns>
        public static string Decrypt(string dataToDecrypt, RSAParameters privateKeyInfo)
        {
            //// The bytearray to hold all of our data after decryption
            byte[] decryptedBytes;
            //Create a new instance of RSACryptoServiceProvider.
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                try
                {
                    byte[] bytesToDecrypt = Convert.FromBase64String(dataToDecrypt);
                    //// Import the private key info
                    RSA.ImportParameters(privateKeyInfo);
                    //// No need to subtract padding size when decrypting (OR do I?)
                    int blockSize = RSA.KeySize / 8;
                    //// buffer to write byte sequence of the given block_size
                    byte[] buffer = new byte[blockSize];
                    //// buffer containing decrypted information
                    byte[] decryptedBuffer = new byte[blockSize];
                    //// Initializes our array to make sure it can hold at least the amount needed to decrypt.
                    decryptedBytes = new byte[dataToDecrypt.Length];
                    for (int i = 0; i < bytesToDecrypt.Length; i += blockSize)
                    {
                        if (2 * i > bytesToDecrypt.Length && ((bytesToDecrypt.Length - i) % blockSize != 0))
                        {
                            buffer = new byte[bytesToDecrypt.Length - i];
                            blockSize = bytesToDecrypt.Length - i;
                        }
                        //// If the amount of bytes we need to decrypt isn't enough to fill out a block, only decrypt part of it
                        if (bytesToDecrypt.Length < blockSize)
                        {
                            buffer = new byte[bytesToDecrypt.Length];
                            blockSize = bytesToDecrypt.Length;
                        }
                        Buffer.BlockCopy(bytesToDecrypt, i, buffer, 0, blockSize);
                        decryptedBuffer = RSA.Decrypt(buffer, false);
                        decryptedBuffer.CopyTo(decryptedBytes, i);
                    }
                }
                finally
                {
                    //// Clear the RSA key container, deleting generated keys.
                    RSA.PersistKeyInCsp = false;
                }
            }
            //// We encode each byte with UTF8 and then write to a string while trimming off the extra empty data created by the overhead.
            var encoder = new UTF8Encoding();
            return encoder.GetString(decryptedBytes).TrimEnd(new[] { '\0' });
        }
