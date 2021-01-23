    static void Main(string[] args)
        {
            DelayedFileSystemWatcher dfw = new DelayedFileSystemWatcher(@"C:\\Test", "*.*");
            dfw.Changed += new FileSystemEventHandler(Program.FileSystemEventHandlerMethod);
            dfw.Created += new FileSystemEventHandler(Program.FileSystemEventHandlerMethod);
            dfw.Deleted += new FileSystemEventHandler(Program.FileSystemEventHandlerMethod);
            dfw.Error += new ErrorEventHandler(Program.ErrorEventHandlerMethod);
            dfw.Renamed += new RenamedEventHandler(Program.RenamedEventHandlerMethod);
    
            dfw.IncludeSubdirectories = true;
            dfw.ConsolidationInterval = 1000;
            dfw.EnableRaisingEvents = true;
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
            //System.Threading.Thread.Sleep(60000);
            dfw.Dispose();
        }
        private static void FileSystemEventHandlerMethod(object sender, FileSystemEventArgs e)
        {
            PrintFileSystemEventHandler(e);
            System.Console.WriteLine();
        }
    
        private static void ErrorEventHandlerMethod(object sender, ErrorEventArgs e)
        {
            System.Console.WriteLine(e.GetException().Message);
            System.Console.WriteLine();
        }
    
        private static void RenamedEventHandlerMethod(object sender, RenamedEventArgs e)
        {
            PrintRenamedEventHandler(e);
            System.Console.WriteLine();
        }
    
        private static void PrintFileSystemEventHandler(FileSystemEventArgs e)
        {
            
        CONVERSION:
            try
            {
    
                if (e.ChangeType != WatcherChangeTypes.Deleted)
                {
                    if (!isFolder(e.FullPath) && isFile(e.FullPath))
                    {
                        FileStream fs = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.None);
                        fs.Close();
                    }
    
                }
                System.Console.WriteLine(e.Name + " " + e.FullPath + " " + e.ChangeType);
    
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("There was an IOException error or File is still copying. Retrying in 2 seconds...");
                System.Threading.Thread.Sleep(2000);
                goto CONVERSION;
            }
    
    
    
            //System.Console.WriteLine(e.Name);
            //System.Console.WriteLine(e.FullPath);
            //System.Console.WriteLine(e.ChangeType);
        }
    
        private static bool isFolder(string strPath)
        {
    
            bool isFolderExist = false;
            try
            {
                isFolderExist = Directory.Exists(strPath);
            }
            catch
            {
                isFolderExist = false;
            }
            return isFolderExist;
        }
    
        private static bool isFile(string strPath)
        {
    
            bool isFileExist = false;
            try
            {
                isFileExist = File.Exists(strPath);
            }
            catch
            {
                isFileExist = false;
            }
            return isFileExist;
        }
    
    
        private static void PrintRenamedEventHandler(RenamedEventArgs e)
        {
            PrintFileSystemEventHandler(e);
            System.Console.WriteLine(e.OldName);
            System.Console.WriteLine(e.OldFullPath);
        }
