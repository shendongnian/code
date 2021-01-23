    public void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
        {
            var files = Directory.GetFiles(path);
            var directories = Directory.GetDirectories(path);
            //this is where I add the empty directory
            //code begin
            if (files.Count() == 0 && directories.Count() == 0)
            {
                DirectoryInfo di = new DirectoryInfo(path);
                string cleanName = ZipEntry.CleanName(path.Substring(folderOffset)) + "/";
                ZipEntry zipEntry = new ZipEntry(cleanName);
                zipEntry.DateTime = di.LastWriteTime;
                zipStream.PutNextEntry(zipEntry);
                zipStream.CloseEntry();
                return;
            }
            //code end
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string cleanName = ZipEntry.CleanName(file.Substring(folderOffset));
                ZipEntry zipEntry = new ZipEntry(cleanName);
                zipEntry.DateTime = fileInfo.LastWriteTime;
                zipEntry.Size = fileInfo.Length;
                zipStream.PutNextEntry(zipEntry);
                byte[] numArray = new byte[4096];
                using (FileStream fileStream = File.OpenRead(file))
                {
                    StreamUtils.Copy(fileStream, zipStream, numArray);
                }
                zipStream.CloseEntry();
            }
            foreach (string directory in directories)
            {
                CompressFolder(directory, zipStream, folderOffset);
            }
        }
