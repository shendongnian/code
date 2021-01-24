    Loom.RunAsync(() => {
            // if using the IPAD
            //client.Connect(IPAddress.Parse(IP), ClientListenPort);
            client.BeginConnect(IPAddress.Parse(IP), ClientListenPort, ClientEndConnect, null);
            while (!client.Connected)
            {
                System.Threading.Thread.Sleep(1);
            }
            //do sth...
        });
    void ClientEndConnect(IAsyncResult result)
    {
        client.EndConnect(result);
    }
