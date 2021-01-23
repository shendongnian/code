    private void PrintOut(baseCheck f)
    {
       Console.WriteLine("Started: {0}", f.StartTime)
       Console.WriteLine("Directory: {0}", f.DirectoryName)
       if (check is FileCheck)
       {
           Console.WriteLine("File: {0}", ((FileCheck)f).FileName}
       }
    }
