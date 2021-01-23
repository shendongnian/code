    private Window window;
    private void OnWindowOpen()
    {
        // still on background thread here
        dispatcher.BeginInvoke(new ThreadStart(() =>
        {
            // now we're on the UI thread
            window = new Window();
            window.Show();
        }
    }
    private void OnWindowClose()
    {
        dispatcher.BeginInvoke(new ThreadStart(() =>
        {
            window.Close();
        }
    }
