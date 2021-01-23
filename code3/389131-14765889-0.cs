    var runspaceConfiguration = RunspaceConfiguration.Create();
    var runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
    var pipeline = runspace.CreatePipeline();    
    
    var myCommand = new Command(String.Format("{0} -Name {1} -Email {2}", taskRun.Task.Script, personsName, personsEmail), true);
    pipeline.Commands.Add(myCommand);
    var result = pipeline.Invoke().FirstOrDefault(); 
