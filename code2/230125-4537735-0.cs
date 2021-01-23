      protected override void OnStart(string[] args)
            {
                _server = new CommandServer("LocalCommandServer", "192.168.10.150", false);
                _serverThread = new Thread(ServerThread);
                _serverThread.Start();
            }
    
            private void ServerThread()
            {
                _server.Initialize("LocalCommandServer", "192.168.10.150");
            }
    
            protected override void OnStop()
            {
                _serverThread.Abort();
                _server.Dispose();
            }
