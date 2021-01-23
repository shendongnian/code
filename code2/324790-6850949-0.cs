            static void Main(string[] args)
            {
                FileSystemWatcher fsw = new FileSystemWatcher(@"C:\Temp", "*.*");
                
                fsw.EnableRaisingEvents = true;
                
                fsw.Created += new FileSystemEventHandler(fsw_Created);
                fsw.Renamed += new RenamedEventHandler(fsw_Renamed);
                fsw.Changed += new FileSystemEventHandler(fsw_Changed);
                
                fsw.IncludeSubdirectories = true;
    
                Console.ReadLine();
            }
    
            static void fsw_Changed(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine("{0} was changed.", e.FullPath);
            }
    
            static void fsw_Renamed(object sender, RenamedEventArgs e)
            {
                Console.WriteLine("{0} was renamed.", e.FullPath);
            }
    
            static void fsw_Created(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine("{0} was created", e.FullPath);
            }
