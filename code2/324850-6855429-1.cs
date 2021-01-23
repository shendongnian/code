    // Called on Page load.
    // Note that there is only one service call with all file names as parameter.
    xClient.Retrieve_FileAsync(fileNames); 
 
    // ...
    // Elsewhere in the class
    BackgroundWorker _worker;
    void xClient_Retrieve_File_Completed(object sender, ServiceReference1.Retrieve_File_CompletedCompletedEventArgs e)
    {
        _worker = new BackgroundWorker()
        _worker.DoWork += (sender, args) =>
        {
            // Only one call to ProcessFile.
            ProcessFile(e.Result);
        };
 
        _worker.RunWorkerCompleted += (sender, args) =>
        {
            // Update UI here
        };
        _worker.RunWorkerAsync();
    }
