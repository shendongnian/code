    PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo("some IP", "user", "pass");
    try
    {
        using (var client = new SshClient(connectionInfo))
        {
            client.Connect();
            var input = new MemoryStream(Encoding.ASCII.GetBytes(command));
            var shell = client.CreateShell(input, Console.Out, Console.Out, "xterm", 80, 24, 800, 600, "");
            shell.Stopped += delegate(object sender, EventArgs e)
            {
                Console.WriteLine("\nDisconnected...");
            };
            shell.Start();
            Thread.Sleep(1000);
            shell.Stop();
            client.Disconnect();
        }   
    }
    catch (Exception ex)
    {
        // Exception stuff
    }
