    private bool close;
    // Shadow Window.Close to make sure we bypass the Hide call in 
    // the Closing event handler
    public new void Close()
    {
        this.close = true;
        base.Close();
    }
    private void Window_Closing(object sender, CancelEventArgs e)
    {
        // If Close() was called, close the window (instead of hiding it)
        if (this.close)
        {
            return;
        }
        // Hide the window (instead of closing it)
        e.Cancel = true;
        this.Hide();
    }
