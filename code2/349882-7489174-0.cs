    public string Encrypt(string toEncrypt)
    {
        var userData = Encoding.Unicode.GetBytes(toEncrypt ?? String.Empty);
        return "password 51:b:" + ToHexString(ProtectedData.Protect(userData, new byte[0], DataProtectionScope.CurrentUser));
    }
    private static string ToHexString(byte[] bytes)
    {
        if (bytes == null)
        {
            return String.Empty;
        }
        return bytes.Aggregate(new StringBuilder(), (sb, b) => sb.AppendFormat("{0:x2}", b)).ToString();
    }
