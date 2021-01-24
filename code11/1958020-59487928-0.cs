           private bool WriteToDisk(string content, string filePath)
            {
                using (FileStream sw = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    byte[] infos = Encoding.UTF8.GetBytes(content);
                    sw.Write(infos, 0, infos.Length);
                }
                return true;
            }
**Notice**: If your file is not exist, create by using this:
            private static void CreateFileIfNotExist(string filePath)
            {
                if (!File.Exists(filePath))
                {
                    var folderPath = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    File.Create(filePath).Dispose();
                }
