    using (var fs = new FileStream(@"c:\temp\test.zip", FileMode.Open, FileAccess.Read))
    {
      using (var zf = new ZipFile(fs))
      {
        foreach (ZipEntry ze in zf)
        {
          if (ze.IsDirectory)
            continue;
            
          Console.Out.WriteLine(ze.Name);            
          using (Stream s = zf.GetInputStream(ze))
          {
            byte[] buf = new byte[4096];
            // Analyze file in memory using MemoryStream.
            using (MemoryStream ms = new MemoryStream())
            {
              StreamUtils.Copy(s, ms, buf);
            }
            // Uncomment the following lines to store the file
            // on disk.
            /*using (FileStream fs = File.Create(@"c:\temp\uncompress_" + ze.Name))
            {
              StreamUtils.Copy(s, fs, buf);
            }*/
          }            
        }
      }
    }
