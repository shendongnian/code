    using System;
    using System.Text;
    using System.Security.Cryptography;
    using System.IO;
    using System.Linq;
    ...
	public static string CreateMd5ForFolder(string path)
	{
		// assuming you want to include nested folders
		var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
							 .OrderBy(p => p).ToList();
	
		MD5 md5 = MD5.Create();
	
		for(int i = 0; i < files.Count; i++)
		{
			string file = files[i];
			
			// hash path
			string relativePath = file.Substring(path.Length + 1);
			byte[] pathBytes = Encoding.UTF8.GetBytes(relativePath.ToLower());
			md5.TransformBlock(pathBytes, 0, pathBytes.Length, pathBytes, 0);
			
			// hash contents
			byte[] contentBytes = File.ReadAllBytes(file);
			if (i == files.Count - 1)
				md5.TransformFinalBlock(contentBytes, 0, contentBytes.Length);
			else
				md5.TransformBlock(contentBytes, 0, contentBytes.Length, contentBytes, 0);
		}
		
		return BitConverter.ToString(md5.Hash).Replace("-", "").ToLower();
	}
