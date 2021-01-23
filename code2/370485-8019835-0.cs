      var bytes = new byte[10000000];
    
      using (var file = new FileStream(filename, FileMode.Open))
      {
        file.Read(bytes, 0, bytes.Length);
      }
    
      var md5 = new MD5CryptoServiceProvider();
      byte[] hash = md5.ComputeHash(bytes); 
