    var ExchangeCredential = new PSCredential(user, password.ToSecureString());
    string serverName = string.Format("{0}.{1}", GetMachinename(), GetDomainName());
    var serverUri = new Uri(String.Format("http://{0}/powershell?serializationLevel=Full", serverName));
    
    var connectionInfo = new WSManConnectionInfo(serverUri,"http://schemas.microsoft.com/powershell/Microsoft.Exchange", ExchangeCredential);
    
    runspace = RunspaceFactory.CreateRunspace(connectionInfo);
    PowerShell psh = PowerShell.Create();
    psh.Runspace = ru
    Pipeline pipeline = runspace.CreatePipeline();
    var command = new Command("Get-MailboxDatabase");
    command.Parameters.Add(new CommandParameter("Status", true));
    pipeline.Commands.Add(command);
    commandResults = pipeline.Invoke();
