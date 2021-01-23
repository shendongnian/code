    Runspace runspace = RunspaceFactory.CreateRunspace();
    runspace.Open();
    RunspaceInvoke invo = new RunspaceInvoke(runspace);
    invo.Invoke("Set-ExecutionPolicy Unrestricted");
    Pipeline pipeline = runspace.CreatePipeline();
    Command command = new Command("get-module -listAvailable | import-module\n" + WriteWhatYouWantToDo);
    pipeline.Commands.Add(command);
    pipeline.Commands.Add("Out-String");
    try
    {
    Collection<PSObject> results = pipeline.Invoke();
    runspace.Close();
    StringBuilder stringBuilder = new StringBuilder();
    foreach (PSObject obj in results)
    {
    stringBuilder.AppendLine(obj.ToString());
    }
    string result1 = stringBuilder.ToString();
    string result = result1.Substring(0, 250); //define global scope
    }
    catch (Exception ex)
    {
    }
