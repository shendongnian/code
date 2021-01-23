	public static void ZipDirectoryKeepRelativeSubfolder(string zipFilePath, string directoryToZip)
    {
        var filenames = Directory.GetFiles(directoryToZip, "*.*", SearchOption.AllDirectories);
        using (var s = new ZipOutputStream(File.Create(zipFilePath)))
        {
            s.SetLevel(9);// 0 - store only to 9 - means best compression
            var buffer = new byte[4096];
            foreach (var file in filenames)
            {
                var relativePath = file.Substring(directoryToZip.Length).TrimStart('\\');
                var entry = new ZipEntry(relativePath);
                entry.DateTime = DateTime.Now;
                s.PutNextEntry(entry);
                using (var fs = File.OpenRead(file))
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
    }
