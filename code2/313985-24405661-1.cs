    InitialSessionState initialSessionState = InitialSessionState.CreateDefault();
    initialSessionState.ApartmentState = ApartmentState.STA;
    initialSessionState.ThreadOptions = PSThreadOptions.UseCurrentThread;
    
    using ( Runspace runspace = RunspaceFactory.CreateRunspace ( initialSessionState ) )
    {
      runspace.Open();
      
      // scripts invocation					
    
      runspace.Close();
    }
