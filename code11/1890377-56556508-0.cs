    public string Encrypt(string plainText)
    {
        byte[] byteData = Encoding.UTF8.GetBytes(plainText);
        byte[] byteResult = Encrypt(byteData); // pt.1
        return Convert.ToBase64String(byteResult);
    }
    public string Decrypt(string cipherText)
    {
        byte[] byteData = Convert.FromBase64String(cipherText);
        byte[] byteResult = Decrypt(byteData); //pt.2
        return Encoding.UTF8.GetString(byteResult);
    }
