    private static byte[] ConvertX509PemToDer(string pemContents)
    {
        return Convert.FromBase64String(pemContents
            .TrimStart("-----BEGIN PUBLIC KEY-----".ToCharArray())
            .TrimEnd("-----END PUBLIC KEY-----".ToCharArray())
            .Replace("\r\n", ""));
    }
