    using (var client = new SshClient("hostnameOrIp", "username", "password"))
    {
        client.Connect();
        client.RunCommand("etc/init.d/networking restart");
        client.Disconnect();
    }
