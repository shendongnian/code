    byte[] keybytes = ParseHex(key);
    byte[] key1 = new byte[8];
    Array.Copy(keybytes, 0, key1, 0, 8);
    byte[] key2 = new byte[8];
    Array.Copy(keybytes, 8, key2, 0, 8);
    DES des1 = DES.Create();
    des1.Key = key1;
    des1.Mode = CipherMode.CBC;
    des1.Padding = PaddingMode.None;
    des1.IV = new byte[8];
    DES des2 = DES.Create();
    des2.Key = key1;
    des2.Mode = CipherMode.CBC;
    des2.Padding = PaddingMode.None;
    des2.IV = new byte[8];
    // MAC Algorithm 3
    byte[] intermediate = des1.CreateEncryptor().TransformFinalBlock(data, 0, data.Length);
    // Output Transformation 3
    byte[] intermediate2 = des2.CreateDecryptor().TransformFinalBlock(intermediate, intermediate.Length - 8, 8);
    byte[] result = des1.CreateEncryptor().TransformFinalBlock(intermediate2, 0, 8);
