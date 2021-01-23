    InitialSessionState initial = InitialSessionState.CreateDefault();
    initialSession.ImportPSModule(new[] { *modulePathOrModuleName* });
    Runspace runspace = RunspaceFactory.CreateRunspace(initial);
    runspace.Open();
    RunspaceInvoke invoker = new RunspaceInvoke(runspace);
    Collection<PSObject> results = invoker.Invoke(*myScript*);
