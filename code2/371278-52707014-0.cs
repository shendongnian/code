    var rnd = new Random(); 
    var key = new byte[32];  // For this example, I'll use a random 32-byte key.
    rnd.NextBytes(key);
    var message = "This is a test";
    // Looping to encrypt the same thing twice just to show that the IV changes.
    for (var i = 0; i < 2; ++i) {
        var aes = new AesCryptoServiceProvider();
        // If you wanted to use the same instance, you can call
        // aes.GenerateIV() to generate a new IV 
        using (var memStream = new System.IO.MemoryStream())
        using (var cryptStream = new CryptoStream(memStream, aes.CreateEncryptor(key, aes.IV), CryptoStreamMode.Write)) {
            var bytes = System.Text.Encoding.Default.GetBytes(message);
            cryptStream.Write(bytes, 0, bytes.Length);
            cryptStream.FlushFinalBlock();
            cryptStream.Close();
            var outBytes = memStream.ToArray();
            var output = Convert.ToBase64String(outBytes, 0, outBytes.Length);
            Console.WriteLine(output);
        }
    }
