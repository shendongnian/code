            var bytes = default(byte[]);
            using (var zip = new ZipFile())
            {
                DirectoryInfo dir = new DirectoryInfo(originalFolder);
                //Here you may need to do recursion for multi-level sub-directories
                foreach (DirectoryInfo diSourceSubDir in dir.GetDirectories())
                {
                    var subName = diSourceSubDir.Name;
                    foreach (FileInfo fi in diSourceSubDir.GetFiles())
                    {
                        byte[] buffer = null;
                        using (FileStream fs = fi.OpenRead())
                        {
                            buffer = new byte[fs.Length];
                            fs.Read(buffer, 0, (int)fs.Length);
                            zip.AddEntry(subName + "\\" + fi.Name, buffer);
                        }
                    }
                }
                using (var ms = new MemoryStream())
                {
                    zip.Save(ms);
                    bytes = ms.ToArray();
                }
            }
            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Zip); 
