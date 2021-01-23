        private static byte[] EncryptBytes(IEnumerable<byte> bytes)
        {
			//The ICryptoTransform is created for each call to this method as the MSDN documentation indicates that the public methods may not be thread-safe and so we cannot hold a static reference to an instance
            using (var r = Rijndael.Create())
            {
                using (var encryptor = r.CreateEncryptor(KEY, IV))
                {
                    return Transform(bytes, encryptor);
                }
            }
        }
        private static byte[] DecryptBytes(IEnumerable<byte> bytes)
        {
            //The ICryptoTransform is created for each call to this method as the MSDN documentation indicates that the public methods may not be thread-safe and so we cannot hold a static reference to an instance
            using (var r = Rijndael.Create())
            {
                using (var decryptor = r.CreateDecryptor(KEY, IV))
                {
                    return Transform(bytes, decryptor);
                }
            }
        }
        private static byte[] Transform(IEnumerable<byte> bytes, ICryptoTransform transform)
        {
            using (var stream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Write))
                {
                    foreach (var b in bytes)
                        cryptoStream.WriteByte(b);
                }
                return stream.ToArray();
            }
        }
