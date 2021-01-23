    public static string SHA256ToString(string s) 
    {
        using (var alg = SHA256.Create())
            return string.Join(null, alg.ComputeHash(Encoding.UTF8.GetBytes(s)).Select(x => x.ToString("x2")));
    }
