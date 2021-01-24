        private async Task StartServerAsync()
        {
            var tcpListener = new TcpListener(new IPEndPoint(IPAddress.Any, 9999));
            tcpListener.Start();
            
            btnStartServer.Enabled = false;
            lbConnectedClients.Items.Add("TcpListener has started listening for clients.");
            while (true)
            {
                var tcpClient = await tcpListener.AcceptTcpClientAsync();
                _ = StartServerSideClient(tcpClient);
            }
        }
        private async void btnStartServer_Click(object sender, EventArgs e)
        {
            await StartServerAsync();
        }
