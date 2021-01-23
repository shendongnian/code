    //
    // Process Client
    // 
    private void ProcessClient(object client, object clientId)
    {
        TcpClient tcpClient = (TcpClient)client;
        int clientRequestId = (int)clientId;
        NetworkStream clientStream = tcpClient.GetStream();
        byte[] clientRequestRaw = new byte[1024];
        int bytesRead;
        UpdateEventLog(new EventLogArgs("(" + clientRequestId + ") Process client request..."));
        while (true)
        {
            bytesRead = 0;
            try
            {
                //blocks until a client sends a message
                bytesRead = clientStream.Read(clientRequestRaw, 0, 512);
            }
            catch (Exception e) 
            {
                //a socket error has occured
                UpdateEventLog(new EventLogArgs("(" + clientRequestId + ") SOCKET ERROR\r\n\r\n" + e));
                break;
            }
            if (bytesRead == 0)
            {
                //the client has disconnected from the server
                UpdateEventLog(new EventLogArgs("(" + clientRequestId + ") Client disconnected from server, nothing sent."));
                break;
            }
            //message has successfully been received.
            ASCIIEncoding encoder = new ASCIIEncoding();
            string clientRequest = encoder.GetString(clientRequestRaw, 0, bytesRead);
            string[] cmd;
            string success;
            Dictionary<string, string> headers = new Dictionary<string, string>();
            Dictionary<string, string> contents = new Dictionary<string, string>();
            if (clientRequest.Length == 0)
            {
                return;
            }
            // Parse HTTP request
            Parse Parse = new Parse();
            Parse.HTTPRequest(clientRequest, out success, out cmd, out headers, out contents);
            string response;
            if (success == "TRUE")
            {
                response = "HTTP/1.1 200 OK\r\n\r\nHello World!\r\n";
            }
            else
            {
                response = "HTTP/1.1 200 OK\r\n\r\nHello Error!\r\n";
            }
            ResponseToClient(client, response);
            clientStream.Close();
            UpdateEventLog(new EventLogArgs("(" + clientRequestId + ") Server response...\r\n\r\n" + response));
        }
        tcpClient.Close();
        UpdateEventLog(new EventLogArgs("(" + clientRequestId + ") Client disconnected."));
    }
