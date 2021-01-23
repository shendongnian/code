    class Example
    {
        static void Main(string[] args)
        {
            byte[] decryptedLibArray;
            using (var fs = new FileStream("clsSo.cDll", FileMode.Open, FileAccess.Read))
            using (var aesProvider = new AesCryptoServiceProvider())
            using (var aesTransform = aesProvider.CreateDecryptor(YourKey, YourIV))
            using (var cryptoStream = new CryptoStream(fs, aesTransform, CryptoStreamMode.Read))
            {
                decryptedLibArray = ReadFully(cryptoStream);
            }
            var lib = Assembly.Load(decryptedLibArray);
            IclsSO classInstance = (IclsSO)lib.CreateInstance("clsSO"); //If you use a namespace this will be namespace.clsSO
            classInstance.myVoid();
            
        }
    
        /// <summary>
        /// Reads data from a stream until the end is reached. The
        /// data is returned as a byte array. An IOException is
        /// thrown if any of the underlying IO calls fail.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        public static byte[] ReadFully (Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read (buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write (buffer, 0, read);
                }
            }
        }
    }
    interface IclsSO
    {
        void myVoid();
    }
