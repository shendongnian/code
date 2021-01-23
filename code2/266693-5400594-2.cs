    private void PrintOut(baseCheck f)
    {
       Console.WriteLine("Started: {0}", f.StartTime)
       Console.WriteLine("Directory: {0}", f.DirectoryName)
    }
    private void PrintOut(FileCheck f)
    {
        PrintOut((baseCheck)f);
        Console.WriteLine("File: {0}", ((FileCheck)f).FileName}
    }
