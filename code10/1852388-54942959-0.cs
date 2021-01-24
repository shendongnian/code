    string value = "123456";
    byte[] valueBytes = new byte[value.Length]; // <-- don't multiply by 2!
    Encoder encoder = Encoding.UTF8.GetEncoder(); // <-- UTF8 here
    encoder.GetBytes(value.ToCharArray(), 0, value.Length, valueBytes, 0, true);
    MD5 md5 = new MD5CryptoServiceProvider();
    byte[] hashBytes = md5.ComputeHash(valueBytes);
    StringBuilder stringBuilder = new StringBuilder();
    for (int i = 0; i < hashBytes.Length; i++)
    {
        stringBuilder.Append(hashBytes[i].ToString("x2"));
    }
    Console.WriteLine(stringBuilder.ToString()); // "e10adc3949ba59abbe56e057f20f883e"
