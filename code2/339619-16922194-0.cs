    public class SimpleListener
    {
        private System.Net.Sockets.TcpListener _tcpListen;
        //declare delegate to handle new connections
        public delegate void _new_client(System.Net.Sockets.TcpClient tcpclient);
        //declare a clients container (or something like...). OPTION 1
        List<System.Net.Sockets.TcpClient> _connected_clients;
        //declare an event and event handler (the same for _new_client) for new connections OPTION 2
        public event _new_client new_tcp_client;
        //public (The list of connected clients).
        public List<System.Net.Sockets.TcpClient> ConnectedClients { get { return _connected_clients; } }
        public SimpleListener(string ip, int listenport)
        {
            System.Net.IPAddress ipAd = System.Net.IPAddress.Parse(ip);
            _tcpListen = new System.Net.Sockets.TcpListener(new System.Net.IPEndPoint(ipAd,listenport));
            _connected_clients = new List<System.Net.Sockets.TcpClient>();
        }
        //Fire this method to start listening...
        public void Listen()
        {
            _tcpListen.Start();
            _set_listen();
        }
        //... and this method to stop listener and release resources on listener
        public void Stop()
        {
            _tcpListen.Stop();
        }
        //This method set the socket on listening mode... 
        private void _set_listen()
        {
            //Let's do it asynchronously - Set the method callback, with the same definition as delegate _new_client
            _tcpListen.BeginAcceptTcpClient(new AsyncCallback(_on_new_client), null);
        }
        //This is the callback for new clients
        private void _on_new_client(IAsyncResult _async_client)
        {
            try
            {
                //Lets get the new client...
                System.Net.Sockets.TcpClient _tcp_cl = _tcpListen.EndAcceptTcpClient(_async_client);
                //Push the new client to the list
                _connected_clients.Add(_tcp_cl);
               //OPTION 2 : Fire new_tcp_client Event - Suscribers will do some stuff...
                if (new_tcp_client != null) 
                {
                    new_tcp_client(_tcp_cl);
                }
                //Set socket on listening mode again... (and wait for new connections, while we can manage the new client connection)
                _set_listen();
            }
            catch (Exception ex)
            {
               //Do something...or not
            }
        }
    }
