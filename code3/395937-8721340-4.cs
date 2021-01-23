    public Stream DownloadFile(string remotePath)
    {
        // initialize FTP client...
    
        BlockingStream blockingStream = new BlockingStream();
    
        // Assign self-removing TransferComplete handler.
        EventHandler<TransferCompleteEventArgs> transferCompleteDelegate = null;
        transferCompleteDelegate = delegate(object sender, TransferCompleteEventArgs e)
        {
            // Indicate to waiting readers that 'end of stream' is reached.
            blockingStream.SetEndOfStream();
            ftp.TransferComplete -= transferCompleteDelegate;
            // Next line may or may not be necessary and/or safe.  Please test thoroughly.
            blockingStream.Close();
            // Also close the ftp client here, if it is a local variable.
        };
        ftp.TransferComplete += transferCompleteDelegate;
    
        // Returns immediately.  Download is still in progress.
        ftp.GetFileAsync(remotePath, blockingStream);
    
        return blockingStream;
    }
