    public static void Connect()
    {
        Task<EA.Repository> _realWork = Task.Run(() => { return new EA.Repository(); });
        Task _timeoutTask = Task.Delay(5000);
        Task.WaitAny(new Task[]{_realWork, timeoutTask});
        if (_timeoutTask.Completed)
        {
            // timed out
        }
        else
        {
            // all good, access _realWork.Result
        }
    }
