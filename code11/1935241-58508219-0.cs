    public void TestMethod()
    {
        string script = @"C:\Users\Desktop\Test_Functions.ps1";
    
        StringBuilder sb = new StringBuilder();
    
        PowerShell psExec = PowerShell.Create();
        psExec.AddScript(script);
        psExec.AddCommand("Update-All Name 'test example'", "Function 'Disable'");
    
        Collection<PSObject> results;
        Collection<ErrorRecord> errors;
        results = psExec.Invoke();
        errors = psExec.Streams.Error.ReadAll();
    
        if (errors.Count > 0)
        {
            foreach (ErrorRecord error in errors)
            {
                sb.AppendLine(error.ToString());
            }
        }
        else
        {
            foreach (PSObject result in results)
            {
                sb.AppendLine(result.ToString());
            }
        }
    
        Console.WriteLine(sb.ToString());
    }
