    Log.CurrentInstance.DisposingProgress += new EventHandler<DisposingEventArgs>(Log_DisposingProgress);
    var thread = new Thread(() =>
    {
        ...
        _dialog.Show();
        while (true)
        {
            lock (currentEventArgsLock)
            {
                if (currentEventArgs != null)
                {
                    _dialog.Value = currentEventArgs.Percentage;
                    if (currentEventArgs.DisposingCompleted)
                    {
                        _dialog.Close();
                        return;
                    }
                }
            }
            Thread.Sleep(20);
        }
    });
    var thread2 = new Thread(() =>
    {
        Log.Dispose();
    });
    thread.Start();
    thread2.Start();
    // make sure both threads finished
    thread.Join();
    thread2.Join();
    return;
    /// <summary>
    /// This function is called to notify about progress changes during disposing of Log.
    /// </summary>
    /// <param name="sender">The sender object.</param>
    /// <param name="e">The event arguments</param>
    protected void Log_DisposingProgress(object sender, DisposingEventArgs e)
    {
        lock (currentEventArgsLock)
        {
            currentEventArgs = e;
        }
    }
