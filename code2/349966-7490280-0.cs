    private void LogAction(string title, Action action)
    {
      Logger.Write(string.Format("Entering %0", title));
    
      action();
    
      Logger.Write(string.Format("Leaving %0", title));
    }
