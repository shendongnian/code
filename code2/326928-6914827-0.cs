    private void OnChanged(object source, FileSystemEventArgs e)
    {
        try
        {
            TB.Text = File.ReadAllText(path);
        }catch(Exception e)
        {
            //Show exception in messagebox or log to file.
        }
    }
