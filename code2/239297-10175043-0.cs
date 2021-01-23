    public void KillMe()
    {
       worker.CancelAsync();
       worker.Dispose();
       worker = null;
       GC.Collect();
    }
