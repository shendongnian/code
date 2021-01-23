    static bool IsFileLocked(FileInfo file)
    {
        FileStream stream = null;
    
        try
        {
            stream = file.Open(FileMode.Open, 
                     FileAccess.ReadWrite, FileShare.None);
        }
        catch (IOException)
        {
            //the file is unavailable because it is:
            //still being written to
            //or being processed by another thread
            //or does not exist (has already been processed)
            return true;
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
    
        //file is not locked
        return false;
    }
    
    static void FswCreated(object sender, FileSystemEventArgs e)
    {
        string sFile = e.FullPath;
    
        Console.WriteLine("processing file : " + sFile);
    
        // Wait if file is still open
        FileInfo fileInfo = new FileInfo(sFile);
        while(IsFileLocked(fileInfo))
        {
            Thread.Sleep(500);
        }
    
        string[] arrLines = File.ReadAllLines(sFile);
    }
