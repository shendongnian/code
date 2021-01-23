    public static string Crypt(this string data, string password, bool encrypt)
    {
        var u8Salt = new byte[] { 0x26, 0x19, 0x81, 0x4E, 0xA0, 0x6D, 0x95, 0x34, 0x26, 0x75, 0x64, 0x05, 0xF6 };
        var iPass = new Rfc2898DeriveBytes(password, u8Salt);
        var iAlg = Aes.Create();
        iAlg.Key = iPass.GetBytes(32);
        iAlg.IV = iPass.GetBytes(16);
        var iTrans = (encrypt) ? iAlg.CreateEncryptor() : iAlg.CreateDecryptor();
        var iMem = new MemoryStream();
        var iCrypt = new CryptoStream(iMem, iTrans, CryptoStreamMode.Write);
        var u8Data = encrypt ? Encoding.Unicode.GetBytes(data) : Convert.FromBase64String(data);
        try
        {
            iCrypt.Write(u8Data, 0, u8Data.Length);
            iCrypt.Close();
            return encrypt ? Convert.ToBase64String(iMem.ToArray()) : Encoding.Unicode.GetString(iMem.ToArray());
        }
        catch
        {
            return null;
        }
    }
