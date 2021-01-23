    public void Main()
    {
      AddHeaderToLogFile();
    }
    
    public void AddHeaderToLogFile()
    {
      Logger headerlogger = LogManager.GetLogger("HeaderLogger");
      
      //Use GlobalDiagnosticContext in 2.0, GDC in pre-2.0
      GlobalDiagnosticContext["releasedate"] = GetReleaseDate();    
      GlobalDiagnosticContext["version"] = GetFileVersion();     
      GlobalDiagnosticContext["someotherproperty"] = GetSomeOtherProperty();
    
      headerlogger.Info("message doesn't matter since it is not specified in the layout");
    
      //Log file should now have the header as defined by the HeaderLayout
    
      //You could remove the global properties now if you are not going to log them in any
      //more messages.
    }
