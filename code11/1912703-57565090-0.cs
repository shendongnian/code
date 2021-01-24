    AesManaged cipher = new AesManaged();
    cipher.Mode = MODE;
    ICryptoTransform encryptor = cipher.CreateEncryptor(KEY, IV);
    MemoryStream to = new MemoryStream();
    CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write);
    writer.Write(input, 0, input.Length);
    writer.FlushFinalBlock();
    byte[] encrypted = to.ToArray();
    return Convert.ToBase64String(encrypted);
