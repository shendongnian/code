    if (LogUtility.IsVerboseEnabled)
    {
        LogUtility.LogVerbose(
            string.Format("Processing event {0}", currentEvent.EventIDImported), 
            MethodBase.GetCurrentMethod().Name, 
            this.GetType().Name
        );
    }
