    if (File.Exists(testfile))
    {
          FileInfo fi = new FileInfo(testfile);
          using (FileStream fs2 = new FileStream(testfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
          {
              using (BinaryReader r = new BinaryReader(fs2))
              {
                  r.BaseStream.Seek(0, SeekOrigin.Begin);                       
                  using (BinaryWriter bw = new BinaryWriter(new FileStream(testfile, FileMode.Open, FileAccess.Write, FileShare.ReadWrite)))                        
                  {
                      for (int i = 0; i <= (fi.Length-177); i += 177)//181
                      {
	 				  }
				  }
			  }
		  }
	}
