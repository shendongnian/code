    using (Runspace runspace = RunspaceFactory.CreateRunspace())
    {
        runspace.Open();
        PowerShell ps = PowerShell.Create();
        ps.Runspace = runspace;
        ps.AddScript(script);
        ps.Invoke();
        ps.AddCommand("BatAvg").AddParameters(new Dictionary<string, string>
        {
            {"Name" , "John"},
            {"Runs", "6996"},
            {"Outs","70"}
        });
    
        foreach (PSObject result in ps.Invoke())
        {
            Console.WriteLine(result);
        }
    }
