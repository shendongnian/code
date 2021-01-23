    string location;
    
    Process p = new Process;
    
    location = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
    +@"\Resources\batchfile.bat";
                 
    p.StartInfo.FileName = location;
