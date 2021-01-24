    public Boolean fileInUse(FileInfo file)
    {
        bool fileInUse = false;
        FileStream stream = null;
        try
        {
            stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            stream.Close();
        }
        catch (IOException)
        {
            //File is in use
            Console.WriteLine("File is Being used");
            fileInUse = true;
        }
    
        Console.WriteLine("File is not in use");
        return fileInUse;    
    }
