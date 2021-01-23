                            //SERVER
           //  instantiate variables such as tempIp, port etc...
           //  ...
           // ...    
            SimpleListener server = new SimpleListener(tempIp, port); //tempIp is the ip address of the server.
            //add handler for new client connections
            server.new_tcp_client += server_new_tcp_client;
            // Start listening for client requests.
            server.Listen();
            .... //No need to loop. The new connection is handled on server_new_tcp_client method
        void server_new_tcp_client(System.Net.Sockets.TcpClient tcpclient)
    {
     	 // Buffer for reading data
                Byte[] bytes = new Byte[MaxChunkSize];
                String data = null;
                Console.WriteLine("Connected!");
    
                    // Get a stream object for reading and writing
                System.IO.Stream stream = tcpclient.GetStream();
    
                   // now that the connection is established start listening though data
                   // sent through the stream..
                    int i;
                    try
                    {
                        // Loop to receive all the data sent by the client.
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
    
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", data);
                           // etc..
                           ....
    }
