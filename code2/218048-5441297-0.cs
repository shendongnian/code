    string[] filenames = Directory.GetFiles(sTargetFolderPath);
 
    // Zip up the files - From SharpZipLib Demo Code
    using (ZipOutputStream s = new
        ZipOutputStream(File.Create("MyZipFile.zip")))
    {
        s.SetLevel(9); // 0-9, 9 being the highest compression
 
        byte[] buffer = new byte[4096];
 
        foreach (string file in filenames)
        {
             ZipEntry entry = new ZipEntry(Path.GetFileName(file));
 
             entry.DateTime = DateTime.Now;
             entry.IsUnicodeText = true;
             s.PutNextEntry(entry);
 
             using (FileStream fs = File.OpenRead(file))
             {
                 int sourceBytes;
                 do
                 {
                     sourceBytes = fs.Read(buffer, 0, buffer.Length);
                     s.Write(buffer, 0, sourceBytes);
 
                 } while (sourceBytes > 0);
             }
        }
        s.Finish();
        s.Close();
     }
 
