using (var client = new SshClient(hostname, username, pwd))
{
    client.Connect();
    var cmd = client.CreateCommand("sleep 15s;echo 123");
    var asynch = cmd.BeginExecute();
    while (!asynch.IsCompleted)
    {
         //  Waiting for command to complete...
         Thread.Sleep(2000);
    }
    result = cmd.EndExecute(asynch);
    client.Disconnect();
}
