    SecureString password = new SecureString();
    string username = "youruseraccount";
    string str_password = "thepassword";
    string exchangeserver = "yourexchangeserver";
    string liveIdconnectionUri = "http://" + exchangeserver +"/Powershell?serializationLevel=Full";
    foreach (char x in str_password) {
        password.AppendChar(x);
    }
    PSCredential credential = new PSCredential(username, password);
    WSManConnectionInfo connectionInfo = new WSManConnectionInfo((new Uri(liveIdconnectionUri)), "http://schemas.microsoft.com/powershell/Microsoft.Exchange",credential);
    connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Default;
    Runspace runspace = System.Management.Automation.Runspaces.RunspaceFactory.CreateRunspace(connectionInfo);
    PowerShell powershell = PowerShell.Create();
    runspace.Open();
    powershell.Runspace = runspace;
    PSCommand command1 = new PSCommand();
    command1.AddCommand("Enable-Mailbox");
    command1.AddParameter("Identity", "dadelgad");
    command1.AddParameter("Database", "NET5014DB10");
    //Add as many parameters as you need
    powershell.Commands = command1;
    powershell.Invoke();
