	public static string CreateDirectoryMd5(string srcPath)
	{
		var filePaths = Directory.GetFiles(srcPath, "*", SearchOption.AllDirectories).OrderBy(p => p).ToArray();
		
		using (var md5 = MD5.Create())
		{
			foreach (var filePath in filePaths)
			{
				// hash path
				byte[] pathBytes = Encoding.UTF8.GetBytes(filePath);
				md5.TransformBlock(pathBytes, 0, pathBytes.Length, pathBytes, 0);
				// hash contents
				byte[] contentBytes = File.ReadAllBytes(filePath);
				md5.TransformBlock(contentBytes, 0, contentBytes.Length, contentBytes, 0);
			}
			//Handles empty filePaths case
			md5.TransformFinalBlock(new byte[0], 0, 0);
			return BitConverter.ToString(md5.Hash).Replace("-", "").ToLower();
		}
	}
