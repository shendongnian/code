    public static string SHA256ToString(string s)
    {            
        using (var alg = SHA256.Create())
            return alg.ComputeHash(Encoding.UTF8.GetBytes(s)).Aggregate(new StringBuilder(), (sb, x) => sb.Append(x.ToString("x2"))).ToString();
    }
