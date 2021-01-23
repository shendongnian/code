     foreach (string eventlogType in LogTypes)
                logWatchers.Add(new EventLogWatcher(eventlogType, EventLogChangeHandler));
            foreach (EventLogWatcher localLog in logWatchers)
            {
                try
                {
                    localLog.EnableCapture();
                }
                catch(Exception ex)
                {
                    EventManager.PublishExceptionLogMessage(ex);
                }
            }
            EventManager.PublishInfoLogMessage($"Started EventLog listeners for {string.Join(",", LogTypes)} logs");
     private void EventLogChangeHandler(string eventLogType, EntryWrittenEventArgs e)
        {
            try
            {
                if (UploadAllowed(eventLogType, e))
                {
                   
                    Dm.EventLog model = _eventLogEntryMapper.MapEntryToModel(e);
                    Task.Factory.StartNew(
                           () => _eventLogUploadService.UploadEventLog(model),
                           _cancellationTokenProvider.Token,
                           TaskCreationOptions.None,
                           TaskScheduler.Default);
                }
            }
            catch(Exception ex)
            {
                EventManager.PublishExceptionLogMessage(ex);
            }
            
        }
