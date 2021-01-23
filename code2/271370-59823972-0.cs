    public static void DeleteAllExcept(string folderPath, List<string> except, bool recursive = true)
    {
        var dir = new DirectoryInfo(folderPath);
        
        //Delete files excluding the list of file names
        foreach (var fi in dir.GetFiles().Where(n => !except.Contains(n.Name)))
        {
            fi.Delete();
        }
    
        //Loop sub directories if recursive == true
        if (recursive)
        {
            foreach (var di in dir.GetDirectories())
            {
                DeleteAllExcept(di.FullName, except, recursive);
            }
        }
    }
