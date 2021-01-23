    using (ZipFile zip = new ZipFile())
    {
       zip.CompressionLevel = CompressionLevel.BestCompression;
       foreach (var entry in entries)
       {
          try
          {
             string newFileName = basefilename + Path.GetExtension(entry.FileName);
             zip.AddFile(newFileName, "");
          }
          catch (Exception) { }
       }
       zip.Save("c:\files\"+basefilename+ ".zip");
    }
