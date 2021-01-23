    void CopyFile(string source, string destination)
    {
        var copy = new FileCopyOperation(source, destination);
        copy.ReplaceExisting = true;
        copy.ProgressChanged += copy_ProgressChanged;
        
        copy.Execute();
    }
    
    void copy_ProgressChanged(object sender, FileOperationProgressEventArgs e)
    {
        copyProgressBar.Value = e.PercentDone;
        
        if (abortRequested)
            e.Action = FileOperationProgressAction.Cancel;
    }
