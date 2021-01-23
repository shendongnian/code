    public static void ConvertFileEncoding(String sourcePath, String destPath)
            {
                // If the destination's parent doesn't exist, create it.
                String parent = Path.GetDirectoryName(Path.GetFullPath(destPath));
                if (!Directory.Exists(parent))
                {
                    Directory.CreateDirectory(parent);
                }
    
                // Convert the file.
                String tempName = null;
                try
                {
                    tempName = Path.GetTempFileName();
                    using (StreamReader sr = new StreamReader(sourcePath))
                    {
                        using (StreamWriter sw = new StreamWriter(tempName, false, Encoding.UTF8))
                        {
                            int charsRead;
                            char[] buffer = new char[128 * 1024];
                            while ((charsRead = sr.ReadBlock(buffer, 0, buffer.Length)) > 0)
                            {
                                sw.Write(buffer, 0, charsRead);
                            }
                        }
                    }
                    File.Delete(destPath);
                    File.Move(tempName, destPath);
                }
                finally
                {
                    File.Delete(tempName);
                }
            }
