    public string GetUniqueFileNameForQuery(string sql)
    {
        using (SHA256 hasher = SHA256.Create())
        {
            var queryBytes = Encoding.UTF8.GetBytes(sql);
            var queryHash = hasher.ComputeHash(queryBytes);
                             // "/" may be included, but is not legal for file names
            return Convert.ToBase64String(queryHash).Replace("/", "-");
        }
    }
