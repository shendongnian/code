    private void WriteToEventLog(string key)
    {
        try
        {
            if (EventLog.SourceExists(ServiceEventSource))
            {
                EventLog.WriteEntry(ServiceEventSource,
                                    string.Format("key:{0}, value:{1}", key, ConfigurationManager.AppSettings[key]));
                _configReadCount = 0;
            }
        }
        catch (Exception)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromMinutes(1)); //sleep for a minute and try again
            _configReadCount++;
            if (_configReadCount <= 3) //try 3 times 
                WriteToEventLog(ConfigKeyCheck);
        }
    }
