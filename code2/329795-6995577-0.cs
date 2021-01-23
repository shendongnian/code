    public static string GetSHA1Hash(string input)
    {
        byte[] bytes = System.Text.Encoding.Default.GetBytes(input ?? string.Empty);
        bytes = System.Security.Cryptography.SHA1.Create().ComputeHash(bytes);
        System.Text.StringBuilder sb = new System.Text.StringBuilder(40);
        for (int i = 0, l = bytes.Length; i < l; i++)
            sb.Append(bytes[i].ToString("x2"));
        return sb.ToString();
    }
