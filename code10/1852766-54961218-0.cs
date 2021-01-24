    private void Connect()
    {
        rdpClient.Server = "10.0.0.13";
        rdpClient.UserName = "test";
        rdpClient.AdvancedSettings2.ClearTextPassword = "test";
        rdpClient.AdvancedSettings8.EnableCredSspSupport = true;
        rdpClient.OnConnecting += RdpClientOnOnConnecting;
        rdpClient.OnConnected += RdpClientOnOnConnected;
        rdpClient.OnWarning += RdpClientOnOnWarning;
        rdpClient.OnFatalError += RdpClientOnOnFatalError;
        rdpClient.Connect();
    }
