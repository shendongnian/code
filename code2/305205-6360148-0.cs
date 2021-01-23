    private System.Threading.Thread _thread;
    
    protected override void OnStart(string[] args)
    {
        try
        {
            // Uncomment this line to debug...
            //System.Diagnostics.Debugger.Break();
    
            // Create the thread object that will do the service's work.
            _thread = new System.Threading.Thread(DoWork);
    
            // Start the thread.
            _thread.Start();
    
            // Log an event to indicate successful start.
            EventLog.WriteEntry("Successful start.", EventLogEntryType.Information);
        }
        catch (Exception ex)
        {
            // Log the exception.
            EvenLog.WriteEntry(ex.Message, EventLogEntryType.Error);
        }
    }
    
    private void DoWork()
    {
        // Do the service work here...
    }
