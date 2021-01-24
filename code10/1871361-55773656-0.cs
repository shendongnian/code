    public void Process(string domainCon)
    {
        this.isActive = true;
        NLog.MappedDiagnosticsLogicalContext.Set("ThreadConnectionString", domainCon);
    
        while (this.isActive)
        {
            try
            {
                StartOperation(domainCon);
            }
            catch (Exception ex)
            {
                //since the Nlog has not been initialised for an individual threads that switch per database, 
                //If any error occurs here, log that in event log instead
                EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
            }
        }
    }
