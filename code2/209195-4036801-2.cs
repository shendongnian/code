        public class SuperServer
        {
            private List<ClientContext> _clients = new List<ClientContext>();
            private SimpleServer _server;
            private Pool<byte[]> _bufferPool;
            public SuperServer()
            {
                // Create a buffer pool to be able to reuse buffers
                // since your clients will most likely connect and disconnect
                // often.
                //
                // The pool takes a anonymous function which should return a new buffer.
                _bufferPool = new Pool<byte[]>(() => new byte[65535]);
            }
            public void Start(IPEndPoint listenAddress)
            {
                _server = new SimpleServer(listenAddress, OnAcceptedSocket);
                // Allow five connections to be queued (to be accepted)
                _server.Start(5); 
            }
            // you should handle exceptions for the BeginSend
            // and remove the client accordingly.
            public void SendToAll(byte[] info)
            {
                lock (_clients)
                {
                    foreach (var client in _clients)
                        client.Socket.BeginSend(info, 0, info.Length, SocketFlags.None, null, null);
                }
            }
            // Server have accepted a new client.
            private void OnAcceptedSocket(Socket socket)
            {
                var context = new ClientContext();
                context.Inbuffer = _bufferPool.Dequeue();
                context.Socket = socket;
                lock (_clients)
                    _clients.Add(context);
                // this method will eat very few resources and
                // there should be no problem having 5000 waiting sockets.
                context.Socket.BeginReceive(context.Inbuffer, 0, context.Inbuffer.Length, SocketFlags.None, OnRead,
                                            context);
            }
            //Woho! You have received data from one of the clients.
            private void OnRead(IAsyncResult ar)
            {
                var context = (ClientContext) ar.AsyncState;
                try
                {
                    var bytesRead = context.Socket.EndReceive(ar);
                    if (bytesRead == 0)
                    {
                        HandleClientDisconnection(context);
                        return;
                    }
                    // process context.Inbuffer here.
                }
                catch (Exception err)
                {
                    //log exception here.
                    HandleClientDisconnection(context);
                    return;
                }
                // use a new try/catch to make sure that we start
                // read again event if processing of last bytes failed.
                try
                {
                    context.Socket.BeginReceive(context.Inbuffer, 0, context.Inbuffer.Length, SocketFlags.None, OnRead,
                                                context);
                }
                catch (Exception err)
                {
                    //log exception here.
                    HandleClientDisconnection(context);
                }
            }
            // A client have disconnected.
            private void HandleClientDisconnection(ClientContext context)
            {
                _bufferPool.Enqueue(context.Inbuffer);
                try
                {
                    context.Socket.Close();
                    lock (_clients)
                        _clients.Remove(context);
                }
                catch(Exception err)
                {
                    //log exception
                }
            }
            // One of your modems
            // add your own state info.
            private class ClientContext
            {
                public byte[] Inbuffer;
                public Socket Socket;
            }
        }
