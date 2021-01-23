       private bool CheckFileHasCopied(string FilePath)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    using (File.OpenRead(FilePath))
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                Thread.Sleep(2000);
                return CheckFileHasCopied(FilePath);
            }
        }
-------------------------------
    if (CheckFileHasCopied(destinationFile)) { File.Delete(sourceFile); }
