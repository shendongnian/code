    public void Stop()
    {
        if (!_backgroundWorker.IsBusy)
        {
            _timer.Enabled = false;
            // Stop/Freeze the main thread until the background worker finishes 
            while (_backgroundWorker.IsBusy)
            {
                Thread.Sleep(100);
            }
        }
    }
