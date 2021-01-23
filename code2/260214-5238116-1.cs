    FileInfo fInfo = new FileInfo(e.FullPath); 
    while(IsFileLocked(fInfo)){
         Thread.Sleep(500);     
    }
    InstallMSI(e.FullPath);
    static bool IsFileLocked(FileInfo file)
    {
        FileStream stream = null;
        try {
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        catch (IOException) {
            return true;
        }
        finally {
            if (stream != null)
                stream.Close();
        }   
        return false;
    }
