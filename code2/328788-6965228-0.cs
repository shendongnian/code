    FileSystemWatcher objWatcher = new FileSystemWatcher(); 
    objWatcher.Filter = "*.*"; 
    objWatcher.Changed += new FileSystemEventHandler(OnChanged); 
    private static void OnChanged(object source, FileSystemEventArgs e) 
    { 
        // get the file's extension 
        string strFileExt = getFileExt(e.FullPath); 
 
        // filter file types 
        if (Regex.IsMatch(strFileExt, @"\.txt)|\.doc", RegexOptions.IgnoreCase)) 
        { 
            Console.WriteLine("watched file type changed."); 
        } 
    } 
