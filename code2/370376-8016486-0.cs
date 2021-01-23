    Socket socket = new Socket(AddressFamily.InterNetwork,
                        SocketType.Stream,
                        ProtocolType.Tcp);
    
    IAsyncResult result = socket.BeginConnect(telco.Address, telco.Port, null, null);
    
    bool connectionSuccess = result.AsyncWaitHandle.WaitOne(5000, true);
