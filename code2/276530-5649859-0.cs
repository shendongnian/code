    private static bool IsRunning = false;
    public void MoveLogs()
    {
        if (!IsRunning)
        {
            IsRunning = true;
            //Copy log files
            IsRunning = false;
        }
    } 
