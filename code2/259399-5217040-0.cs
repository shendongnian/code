    string GetEncodedHash(string password, string salt)
    {
       MD5 md5 = new MD5CryptoServiceProvider();
       byte [] digest = md5.ComputeHash(Encoding.UTF8.GetBytes(password + salt);
       string base64digest = Convert.ToBase64String(digest, 0, digest.Length);
       return base64digest.Substring(0, base64digest.Length-2);
    }
