    public class ClientConnection {
        private Socket _socket;        
        public ClientConnection(Socket socket) {
            _socket = socket;
            new Thread(HandleClientRequests);
        }
        /* snip */
        public void HandleClientRequests() {
            bool disconnectRequested = false;
            while(!disconnectRequested) {
                var message = ReadNextMessageFromSocket();
                if(message.Type == MessageType.CloseConnection) {
                    disconnectRequested = true;
                } else {
                    //service request and send response
                }
            }
            ShutdownConnection();
            //after this point the thread terminates
        }
    }
