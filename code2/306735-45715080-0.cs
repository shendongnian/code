    public static void DeleteFile(string path)
            {
                if (!File.Exists(path))
                {
                    return;
                }
    
                bool isDeleted = false;
                while (!isDeleted)
                {
                    try
                    {
                        File.Delete(path);
                        isDeleted = true;
                    }
                    catch (Exception e)
                    {
                    }
                    Thread.Sleep(50);
                }
            }
