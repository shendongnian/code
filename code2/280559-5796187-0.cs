    class Comms
    {
        TcpListener listener;
        TcpClient client;
    
        // Starts listening for a tcp client
        public void StartListener()
        {
            listener = new TcpListener(IPAddress.Any, 123);
            listener.BeginAcceptTcpClient(new AsyncCallback(ClientCallback), listener);
        }
        // Callback for when a client connects on the port
        void ClientCallback(IAsyncResult result)
        {
            listener = (TcpListener)result.AsyncState;
            try
            {
                client = listener.EndAcceptTcpClient(result);
                // From here you can access the stream etc and read data
            }
            catch (IOException e)
            {
                // Handle any exceptions here 
            }
        }
    }
            
