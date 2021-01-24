    // create the socket
    public static Socket listenSocket = new Socket(AddressFamily.InterNetwork, 
                                            SocketType.Stream,
                                            ProtocolType.Tcp);
    
    // bind the listening socket to the port
    IPAddress hostIP = (Dns.Resolve(IPAddress.Any.ToString())).AddressList[0];
    IPEndPoint ep = new IPEndPoint(hostIP, port);
    if(!listenSocket.IsBound){
      listenSocket.Bind(ep);     
      // start listening
      listenSocket.Listen(backlog);
    }
    // connect client 
    ModbusClient client = null;
    client = new ModbusClient(hostIP , port);
    client.Connect();
