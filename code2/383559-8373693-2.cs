    List<TcpClient> clients = new List<TcpClient>();
    
    private void ListenForClients()
    {
         this.tcpListener.Start();
    
         while (true)
         {
              //blocks until a client has connected to the server
              TcpClient client = this.tcpListener.AcceptTcpClient();
              if(!clients.Contains(clients))
                  clients.Add(client);
         }
    }
