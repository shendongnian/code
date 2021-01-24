    // add new lock object
    object lockObject = new object();
    FileStream fs = null;
    int filecount = 0;
    long a = 1000000000000000;
    …
    private void WriteINFile()
    {
        string sen = " write in file ";
        for (int i = 0; i < a; i++)
        {
            Byte[] title = new UTF8Encoding(true).GetBytes(sen);
            lock (lockObject)
            {
                fs.Write(title, 0, title.Length);
            }
        }
    }
    …
    
    private void Commitzfile()
    {
        lock(lockObject)
        {
            fs.Flush();
            fs.Close();
            filecount++;
            initialiseFile(filecount);
        }
    }
