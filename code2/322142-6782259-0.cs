    public string GetPasswordHash(string clearPassword)
    {
        using (var hash = new System.Security.Cryptography.SHA256Managed())
        {
            var hashBytes = System.Text.Encoding.UTF8.GetBytes(clearPassword);
            return Convert.ToBase64String(hash.ComputeHash(hashBytes));
        }
    }
