    protected override OnFormClosing()
    {
        e.Cancel = true;
    
        if (!thread1.IsBusy && !thread2.IsBusy)
           this.Close();
    
        stopThreads();
    }
    private void thread1_RunWorkerCompleted(sender, e)
    {
           if (!thread2.IsBusy)
              this.Close();
    }
    private void thread2_RunWorkerCompleted(sender, e)
    {
           if (!thread1.IsBusy)
              this.Close();
    }
