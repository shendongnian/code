    private void OnError(object source, ErrorEventArgs e)
    {
        if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
        {
            txtResults.Text += "Error: File System Watcher internal buffer overflow at " + DateTime.Now + "\r\n";
        }
        else
        {
            txtResults.Text += "Error: Watched directory not accessible at " + DateTime.Now + "\r\n";
        }
        NotAccessibleError(fileSystemWatcher ,e);
    }
