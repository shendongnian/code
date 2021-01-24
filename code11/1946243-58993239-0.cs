    //create listener
            listener = new TcpListener(IPAddress.Any, ClientListenPort);
            listener.Start();
            listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
    Loom.RunAsync(() => {
                    while (!stop)
                    {
                        // Wait for client connection
                        clients.Add(listener.AcceptTcpClient());
                        clients[clients.Count - 1].NoDelay = true;
                        // We are connected
                        isConnected = true;
                        streams.Add(clients[clients.Count - 1].GetStream());
                        streams[streams.Count - 1].WriteTimeout = 500;
                        Loom.QueueOnMainThread(() => {
                            isConnected = true;
                        });
                        System.Threading.Thread.Sleep(1);
                    }
                });
