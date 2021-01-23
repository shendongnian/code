    // Download File
    WebClient wc = new WebClient();
    byte[] bytes = wc.DownloadData();
    
    MD5 md5 = System.Security.Cryptography.MD5.Create();
    byte[] hash = md5.ComputeHash(bytes);
    
    StringBuilder onlineFile = new StringBuilder();
    for (int i = 0; i < hash.Length; i++)
    {
       onlineFile.Append(hash[i].ToString("X2"));
    }
    
    // Load Local File
    FileStream fs = new FileStream(@"c:\yourfile.txt",FileMode.Open);
    byte[] fileBytes = new byte[fs.Length];
    fs.Read(fileBytes, 0, fileBytes.Length);
    
    byte[] hash = md5.ComputeHash(fileBytes);
    
    StringBuilder localFile = new StringBuilder();
    for (int i = 0; i < hash.Length; i++)
    {
       onlineFile.Append(hash[i].ToString("X2"));
    }
    
    
    if(localFile.ToString() == onlineFile.ToString())
    {
       // Match
    }
