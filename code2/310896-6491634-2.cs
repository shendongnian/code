    public static bool IsFileInUse(string fileFullPath, bool throwIfNotExists)
    {
        if (System.IO.File.Exists(fileFullPath))
        {
            try
            {
                //if this does not throw exception then the file is not use by another program
                using (FileStream fileStream = File.OpenWrite(fileFullPath))
                {
                    if (fileStream == null)
                        return true;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }
        else if (!throwIfNotExists)
        {
            return true;
        }
        else
        {
            throw new FileNotFoundException("Specified path is not exsists", fileFullPath);
        }
    }
