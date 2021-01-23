    public string GetFileHash(string fileName)
    {
        using (var stream = File.Open(fileName, FileMode.Open))
        {
            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(stream);
            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
