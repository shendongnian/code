    protected override void OnStart(string[] args)
    {
        try
        {
            DoStart();
        }
        catch (Exception exp)
        {
            Win32Exception w32ex = exp as Win32Exception;
            if (w32ex == null)
            {
                w32ex = exp.InnerException as Win32Exception;
            }
            if (w32ex != null)
            {
                ExitCode = w32ex.ErrorCode;
            }
            Stop();
        }
    }
