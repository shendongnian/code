    var files = GetFiles(directoryToScan);
    tokenSource = new CancellationTokenSource();
    CancellationToken ct = tokenSource.Token;
    Task task = Task.Factory.StartNew(delegate
    {
        // Were we already canceled?
        ct.ThrowIfCancellationRequested();
        Parallel.ForEach(files, currentFile =>
        {
            // Poll on this property if you have to do 
            // other cleanup before throwing. 
            if (ct.IsCancellationRequested)
            {
                // Clean up here, then...
                ct.ThrowIfCancellationRequested();
            }
            ProcessFile(directoryToScan, currentFile, directoryToOutput);
            // Update calling thread's UI
            Invoke((Action)(() =>
            {
                WriteProgress(currentFile);
            }));
        });
    }, tokenSource.Token); // Pass same token to StartNew.
    task.ContinueWith((t) =>
            Invoke((Action)(() =>
            {
                SignalCompletion(sw);
            }))
    );
