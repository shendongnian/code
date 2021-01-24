    using (HttpClient client = new HttpClient())
    {
    	if (!path.EndsWith("/")) path = $"{path}/";
    	string url = config.CreateRequest(client, null, $"{path}{file.Name}");
    	string sha1 = JFrogLoader.GetSha1Hash(file);
    	string sha256 = JFrogLoader.GetSha256Hash(file);
    	string md5 = JFrogLoader.GetMD5Hash(file);
    	using (Stream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    	{
    		StreamContent content = new StreamContent(stream);
    		content.Headers.Add("Content-Type", "application/octet-stream");
    		client.DefaultRequestHeaders.Add("X-Checksum-Deploy", "true");
    		client.DefaultRequestHeaders.Add("X-Checksum-Sha1", sha1);
    		client.DefaultRequestHeaders.Add("X-Checksum-Sha256", sha256);
    		client.DefaultRequestHeaders.Add("X-Checksum-Md5", md5);
    		HttpResponseMessage message = await client.PutAsync(url, content);
    
    		string response = await message.Content.ReadAsStringAsync();
    		return message.StatusCode == System.Net.HttpStatusCode.Created;
    	}
    }
    
    public static string GetSha1Hash(FileInfo file)
    {
    	using (var sha1 = new SHA1CryptoServiceProvider())
    	{
    		return JFrogLoader.GetHash(file, sha1);
    	}
    }
    
    public static string GetSha256Hash(FileInfo file)
    {
    	using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
    	{
    		return JFrogLoader.GetHash(file, sha256);
    	}
    }
    
    public static string GetMD5Hash(FileInfo file)
    {
    	using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
    	{
    		return JFrogLoader.GetHash(file, md5);
    	}
    }
    
    private static string GetHash(FileInfo file, HashAlgorithm hasher)
    {
    	using (Stream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    	{
    		byte[] hash = hasher.ComputeHash(stream);
    		return BitConverter.ToString(hash).Replace("-", "").ToLower();
    	}
    }
