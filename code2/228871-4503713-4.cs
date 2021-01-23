    string decryptedString1 = string.Empty;
    foreach (byte b in decryptedBytes)
    {
        decryptedString1 += (char)b;
    }
    string decryptedString2 = ByteConverter.GetString(decryptedBytes);
