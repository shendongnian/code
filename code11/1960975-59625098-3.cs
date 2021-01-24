csharp
	var auth1 = new PasswordAuthenticationMethod(username.Text, password.Text);
	var auth2 = new KeyboardInteractiveAuthenticationMethod(username.Text);
	ConnectionInfo conInfo = new ConnectionInfo(host.Text, username.Text, auth1, auth2);
...
		//first you run your command
	var sshClient = new SshClient(conInfo);
	sshClient.Connect();
	var cmd = sshClient.RunCommand("ls");
	var r = cmd.Execute();
	
	//then you reuse credentials and upload your file
	
	var scpclient = new ScpClient(conInfo);
	scpclient.Connect(); // note you have to .connect() for the second time. this is due to library not providing any obvious ways to share session between clients
	/*
    need to run a command 
    */
	FileInfo file = new FileInfo("d:\\1.txt");
	scpclient.Upload(file, "~");
}
the way library is written seems to force into establishing two connections here, this can probably be overcome by inheriting from `BaseClient` and implementing your actions (most likely you just need to copy relevant methods from respective classes) 
----------
**UPD** as we already established, you want to keep your connection alive between operations, and therefore avoid doing the above. This is somewhat tricky as the library hides internal `Session` object and does not allow you to reuse it.
You however can still inherit from one of the clients (`ScpClient` seemed like a good base to start) and implement the `CreateCommand` method like so:
csharp
public class RunAndUpload : ScpClient
{	
	public RunAndUpload(ConnectionInfo connectionInfo)
			: base(connectionInfo)
	{
	}
	public SshCommand CreateCommand(string commandText)
	{
		var pi = typeof(RunAndUpload).GetProperty("Session", BindingFlags.NonPublic | BindingFlags.Instance);
		var command = (SshCommand)typeof(SshCommand).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0].Invoke(new object[] {pi.GetValue(this), commandText, this.ConnectionInfo.Encoding} );		
		return command;
	}
}
you will notice I had to opt for reflection just to instantiate the `SshCommand` (as it's constructor is internal to the library and normally would not be exposed). Once you past the stage of obtaining a command instance - it should all be smooth from there:
csharp 
    using(var sshClient = new RunAndUpload(conInfo)) {
		sshClient.Connect();		
		var cmd = sshClient.CreateCommand("ls");
		var r = cmd.Execute();
		FileInfo file = new FileInfo("d:\\1.txt");
		sshClient.Upload(file, "1.txt");
	}
hopefully that works for you
  [1]: https://github.com/sshnet/SSH.NET
