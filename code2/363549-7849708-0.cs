    // Generate key. You do it once and save the key in the code
    var encryptorForGenerateKey = Aes.Create();
    encryptorForGenerateKey.BlockSize = 128;
    encryptorForGenerateKey.KeySize = 128;
    encryptorForGenerateKey.GenerateKey();
    encryptorForGenerateKey.GenerateIV();
    var key = encryptorForGenerateKey.Key;
    var iv = encryptorForGenerateKey.IV;
    // Encrypt: this code doesn't need to be in the program. You create a console
    // program to do it
    var encryptor = Aes.Create();
    var encryptorTransformer = encryptorForGenerateKey.CreateEncryptor(key, iv);
            
    string str = "Hello world";
    var bytes = Encoding.UTF8.GetBytes(str);
    var encrypted = encryptorTransformer.TransformFinalBlock(bytes, 0, bytes.Length);
    var encryptedString = Convert.ToBase64String(encrypted);
    Console.WriteLine(encryptedString);
    // Decrypt: this code needs to be in the program
    var decryptor = Aes.Create();
    var decryptorTransformer = decryptor.CreateDecryptor(key, iv);
    byte[] encrypted2 = Convert.FromBase64String(encryptedString)
    var result = decryptorTransformer.TransformFinalBlock(encrypted2, 0, encrypted2.Length);
    var str2 = Encoding.UTF8.GetString(result);
