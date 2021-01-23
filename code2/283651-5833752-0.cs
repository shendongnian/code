    static void LogFile(string lockedFilePath)
            {
                Assembly ass = Assembly.GetExecutingAssembly();
                string workingFolder = System.IO.Path.GetDirectoryName(ass.Location);
                string LogFile = System.IO.Path.Combine(workingFolder, "logFiles.txt");
    
                System.IO.File.AppendAllText(LogFile, System.Environment.NewLine + lockedFilePath);
    
            }
