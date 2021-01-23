    count = DirectoryFiles.Length;
    for (int k = 0; k < count; k++)
    {
        FileInfo file = DirectoryFiles[k];
        if ((file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden || 
            (file.Attributes & FileAttributes.System) == FileAttributes.System)
        {
            continue;
        }
    
        backgroundWorkerLoadDir.ReportProgress(i, file.Name);
        System.Threading.Thread.Sleep(10);
    }
