    public static void Connect()
    {
        Task<EA.Repository> _realWork = Task.Run(() => { return new EA.Repository(); });
        var completedTaskIndex = Task.WaitAny(new Task[]{timeoutTask}, 5000);
        if (completedTaskIndex == -1)
        {
            // timed out
        }
        else
        {
            // all good, access _realWork.Result
        }
    }
