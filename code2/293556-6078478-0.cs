    public void ProcessAllFilesOnDrive()
    {
        ProcessFiles(@"c:\");
    }
    private void ProcessFiles(string path)
    {
        Directory.GetFiles(path).ToList().ForEach(Process);
        Directory.GetDirectories(path).ToList().ForEach(ProcessFiles);
    }
    private void Process(string filename)
    {
        // do something to file
    }
