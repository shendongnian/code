    public static string CreateMD5(string input, int iterations)
    {
        // Use input string to calculate MD5 hash
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            // modification from linked answer: iterate N times
            for (int i = 1; i < iterations; ++i)
            {
                hashBytes = md5.ComputeHash(hashBytes);
            }
            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
    public static string enPwd(string username, string pwd)
    {
        return CreateMD5(username + pwd, 2);
    }
