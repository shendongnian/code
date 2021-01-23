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
                decryptedLibArray = ReadToEnd(cryptoStream);
            }
            var lib = Assembly.Load(decryptedLibArray);
            IclsSO classInstance = (IclsSO)lib.CreateInstance("clsSO"); //If you use a namespace this will be namespace.clsSO
            classInstance.myVoid();
            
        }
    }
    interface IclsSO
    {
        void myVoid();
    }
