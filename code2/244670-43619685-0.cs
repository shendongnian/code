    public ExceptionDispatchInfo _error { get; private set; }
    
    public bool IsValid()
    {
        try
        {
            //do something here to cause exception                
    
            return true;
        }
        catch (Exception ex)
        {
            _error = ExceptionDispatchInfo.Capture(ex);
            return false;
        }
    }
    
    /// <summary>Throw underlying exception if invalid.</summary>
    public void AssertWasValid() => _error?.Throw();
