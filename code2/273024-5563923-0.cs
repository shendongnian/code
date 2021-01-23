    private void BWDoWork(...)
    {
        for (...)
        {
            // ...
            worker.ReportProgress(...);
        }
    }
    
    private void BWReportProgress(...)
    {
        // do something on the MyWindow thread
    }
    
    private void BWCompleted(...)
    {
        this.Close();
    }
