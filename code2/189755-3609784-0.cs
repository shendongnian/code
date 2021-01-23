    public class Server()
    {
        private Socket sock;
        // You'll probably want to initialize the port and address in the
        // constructor, or via accessors, but to start your server listening
        // on port 8080 and on any IP address available on the machine...
        private int port = 8080;
        private IPAddress addr = IPAddress.Any;
        
        // This is the method that starts the server listening.
        public void Start()
        {
            // Create the new socket on which we'll be listening.
            this.sock = new Socket(
                addr.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);
            // Bind the socket to the address and port.
            sock.Bind(new IPEndPoint(this.addr, this.port));
            // Start listening.
            this.sock.Listen(this.backlog);
            // Set up the callback to be notified when somebody requests
            // a new connection.
            this.sock.BeginAccept(this.OnConnectRequest, sock);
        }
    
        // This is the method that is called when the socket recives a request
        // for a new connection.
        private void OnConnectRequest(IAsyncResult result)
        {
            // Get the socket (which should be this listener's socket) from
            // the argument.
            Socket sock = (Socket)result.AsyncState;
            // Create a new client connection, using the primary socket to
            // spawn a new socket.
            Connection newConn = new Connection(sock.EndAccept(result));
            // Tell the listener socket to start listening again.
            sock.BeginAccept(this.OnConnectRequest, sock);
        }
    }
