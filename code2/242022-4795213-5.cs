    private void MyMethod()
    {
        List<string> fileNames = new List<string>();
        GetFileNames(@"C:\my\base\directory", fileNames);
    }
    
    private void GetFileNames(string directory, List<string> files)
    {
        files.AddRange(System.IO.Directory.GetFiles(directory));
    
        foreach(string subDirectory in System.IO.Directory.GetDirectories(directory))
        {
            GetFileNames(subDirectory, files);
        }
    }
