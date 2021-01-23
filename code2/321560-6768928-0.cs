    if (Directory.Exists(dirPath))
            {
                try
                {
                    File.Copy(sourceFile, destFile);
                }
                catch (Exception msg)
                {
                    //Handle Exception.
                }
            }
