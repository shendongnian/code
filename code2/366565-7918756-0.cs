    string cmd = @"Get-ChildItem $home\Documents -recurse | " +
                  "Where {!$_.PSIsContainer -and ($_.LastWriteTime -gt (Get-Date).AddDays(-7))} | " +
                  "Sort Fullname | Foreach {$_.Fullname}";
    
    Runspace runspace = null;
    Pipeline pipeline = null;
    
    try
    {
        runspace = RunspaceFactory.CreateRunspace();
        runspace.Open();
        pipeline = runspace.CreatePipeline(cmd))
        pipeline.Commands.AddScript(cmd);
        Collection<PSObject> results = pipeline.Invoke();
        foreach (PSObject obj in results)
        {
            // Consume the results
            Debug.WriteLine(obj);    
        }
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex);
    }
    finally
    {
        if (pipeline != null) pipeline.Dispose();
        if (runspace != null) runspace.Dispose();
    }
