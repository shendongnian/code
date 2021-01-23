    // Generate key. You do it once and save the key in the web.config or in the code
    var encryptorForGenerateKey = Aes.Create();
    encryptorForGenerateKey.BlockSize = 128;
    encryptorForGenerateKey.KeySize = 128;
    encryptorForGenerateKey.GenerateKey();
    encryptorForGenerateKey.GenerateIV();
    var key = encryptorForGenerateKey.Key;
    var iv = encryptorForGenerateKey.IV;
    // Encrypt
    var encryptor = Aes.Create();
    var encryptorTransformer = encryptorForGenerateKey.CreateEncryptor(key, iv);
            
    int id = 123;
    var bytes = BitConverter.GetBytes(id);
    var encrypted = encryptorTransformer.TransformFinalBlock(bytes, 0, bytes.Length);
    var encryptedString = BitConverter.ToString(encrypted);
    Console.WriteLine(encryptedString);
    // Decrypt
    var decryptor = Aes.Create();
    var decryptorTransformer = decryptor.CreateDecryptor(key, iv);
    String[] arr = encryptedString.Split('-');
    byte[] encrypted2 = new byte[arr.Length];
    for (int i = 0; i < arr.Length; i++)
    {
        encrypted2[i] = Convert.ToByte(arr[i], 16);
    }
    // If the block is irregular there is the possibility TransformFinalBlock will throw
    var result = decryptorTransformer.TransformFinalBlock(encrypted2, 0, encrypted2.Length);
    if (result.Length != sizeof(int))
    {
        throw new Exception();
    }
    var id2 = BitConverter.ToInt32(result, 0);
