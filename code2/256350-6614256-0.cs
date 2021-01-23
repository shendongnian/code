    Runspace runspace = RunspaceFactory.CreateRunspace();
    runspace.Open();
    Pipeline pipeline = runspace.CreatePipeline();
    Command myCommand = new Command("C:\\Scripts\\Test.ps1");
    //I used full path name here, not sure if you have to or not 
    CommandParameter myParam1 = new CommandParameter("-ServerName", "myServer");
    myCommand.Parameters.Add(myParam1);
    //You can add as many parameters as you need to here
    pipeline.Commands.Add(myCommand);
    Collection<PSObject> results = pipeline.Invoke();
    runspace.Close();
    StringBuilder stringBuilder = new StringBuilder()
    foreach (PSObject obj in results) {
        stringBuilder.AppendLine(obj.ToString());
    }
    string thestring = stringBuilder.ToString();
