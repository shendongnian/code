	static void Main(string[] args)
	{
		SecureString password = new SecureString();
		string str_password = "PASS";
		string username = "domain\\user";
		//FQDN is ofcourse the (fully qualified) name of our exchange server.. 
		string liveIdconnectionUri = "http://SERVERFQDN/Powershell?serializationLevel=Full";
		foreach (char x in str_password)
		{
			password.AppendChar(x);
		}
		PSCredential credential = new PSCredential(username, password);
		WSManConnectionInfo connectionInfo = new WSManConnectionInfo((new Uri(liveIdconnectionUri)), "http://schemas.microsoft.com/powershell/Microsoft.Exchange", credential);
		Runspace runspace = null;
		PowerShell powershell = PowerShell.Create();
		PSCommand command = new PSCommand();
		command.AddCommand("Get-Mailbox");
		command.AddParameter("Identity", "USERIDENT");
		powershell.Commands = command;
		try
		{
			connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Default;
			runspace = System.Management.Automation.Runspaces.RunspaceFactory.CreateRunspace(connectionInfo);
			runspace.Open();
			powershell.Runspace = runspace;
			Collection<PSObject> commandResults = powershell.Invoke<PSObject>();
			foreach (PSObject result in commandResults)
			{
				Console.WriteLine(result.ToString());
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		finally
		{
			runspace.Dispose();
			runspace = null;
			powershell.Dispose();
			powershell = null;
		} 
	}
