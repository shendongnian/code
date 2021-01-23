    System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create();
    System.Security.Cryptography.ICryptoTransform enc = aes.CreateEncryptor();
    // byte[] input;
    // byte[] output = new output[512]
    int size = enc.TransformBlock(input, 0, input.Length, output, 0);
