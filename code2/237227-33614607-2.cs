    protected override void OnStart(string[] args)
    {
        try
        {
            RequestAdditionalTime(600000);
            System.Diagnostics.Debugger.Launch(); // Put breakpoint here.
            .... Your code
        }
        catch (Exception ex)
        {
            .... Your exception code
        }
    }
