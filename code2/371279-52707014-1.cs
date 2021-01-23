    private static void Main(string[] args) {
        var rnd = new Random(); 
        var key = new byte[32];  // For this example, I'll use a random 32-byte key.
        rnd.NextBytes(key);
        var message = "This is a test";
        // Looping to encrypt the same thing twice just to show that the IV changes.
        for (var i = 0; i < 2; ++i) {
            var encrypted = EncryptString(message, key);
            Console.WriteLine(encrypted);
            Console.WriteLine(DecryptString(encrypted, key));
        }
    }
    public static string EncryptString(string message, byte[] key) {
        var aes = new AesCryptoServiceProvider();
        var iv = aes.IV;
        using (var memStream = new System.IO.MemoryStream()) {
            memStream.Write(iv, 0, iv.Length);  // Add the IV to the first 16 bytes of the encrypted value
            using (var cryptStream = new CryptoStream(memStream, aes.CreateEncryptor(key, aes.IV), CryptoStreamMode.Write)) {
                using (var writer = new System.IO.StreamWriter(cryptStream)) {
                    writer.Write(message);
                }
            }
            var buf = memStream.ToArray();
            return Convert.ToBase64String(buf, 0, buf.Length);
        }
    }
    public static string DecryptString(string encryptedValue, byte[] key) {
        var bytes = Convert.FromBase64String(encryptedValue);
        var aes = new AesCryptoServiceProvider();
        using (var memStream = new System.IO.MemoryStream(bytes)) {
            var iv = new byte[16];
            memStream.Read(iv, 0, 16);  // Pull the IV from the first 16 bytes of the encrypted value
            using (var cryptStream = new CryptoStream(memStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read)) {
                using (var reader = new System.IO.StreamReader(cryptStream)) {
                    return reader.ReadToEnd();
                }
            }
        }  
    }
