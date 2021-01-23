    using (FileStream fs = File.OpenRead(filePath))
    {
         ZipFile zf = ZipFile.Read(fs);
         ICollection<ZipEntry> entries = zf.Entries;
         foreach (ZipEntry entry in entries)
         {
              string path = entry.FileName; // 
         }
    }
