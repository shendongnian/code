    using( var runspace = RunspaceFactory.Create() )
    {
      runspace.Open();
      using( var pipeline = runspace.CreatePipeline( "./myscript.ps1" ) )
      {
        Collection<PSObject> results = pipeline.Invoke();
        // ... process the results of running myscript.ps1
      }
    }
