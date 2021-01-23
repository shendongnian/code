    public class SomeEncryption : IDisposable
        {
            private MemoryStream memoryStream;
    
            private CryptoStream cryptoStream;
    
            public static byte[] Encrypt(string data, byte[] key, byte[] iv)
            {
                 // Do something
                 this.memoryStream = new MemoryStream();
                 this.cryptoStream = new CryptoStream(this.memoryStream, encryptor, CryptoStreamMode.Write);
                 using (var streamWriter = new StreamWriter(this.cryptoStream))
                 {
                     streamWriter.Write(plaintext);
                 }
                return memoryStream.ToArray();
            }
           public void Dispose()
            { 
                 this.Dispose(true);
                 GC.SuppressFinalize(this);
            }
           protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (this.memoryStream != null)
                    {
                        this.memoryStream.Dispose();
                    }
                    if (this.cryptoStream != null)
                    {
                        this.cryptoStream.Dispose();
                    }
                }
            }
       }
