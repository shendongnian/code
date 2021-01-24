        static void Main(string[] args)
        {
            // target main folder
            string directoryName = @"E:\Apps\2019\SADtest\Decupe\SADtest\Veriler\sources\";
    
            // such as only watch JPG files
            string fileExtension = "*.jpg";
    
       
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                // NotifyFilter is Flag attribute.
                // triggers when file names created, changed or updated.
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.LastWrite;
                watcher.Path = directoryName;
    
                // the Filter propertie must contain wildcards or empty.
                // you cannot write multiple extensions.
                // all files  : *.* 
                // only text  : *.txt 
                // ends withs : *test2.txt
                watcher.Filter = fileExtension;
    
                // track the same extensions in all subdirectories.
                watcher.IncludeSubdirectories = true;
    
                // register events
                watcher.Created += Watcher_Created;
                watcher.Deleted += Watcher_Deleted;
                watcher.Renamed += Watcher_Renamed;
    
                // begin watching...
                watcher.EnableRaisingEvents = true;
    
                // sample message
                Console.WriteLine("Press 'ENTER' to quit watching.");
                Console.WriteLine($"I am watching the files with the '{fileExtension}' extension in the '{directoryName}' directory.");
    
                // wait for the user to quit the program.
                Console.WriteLine();
             
                Console.Read();
            }
        }
    
        private static void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Renamed:File: {e.OldFullPath} renamed to {e.FullPath}");
        }
    
        private static void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Deleted:File: {e.FullPath} {e.ChangeType}");
        }
    
        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Created:File: {e.FullPath} {e.ChangeType}");
        }
