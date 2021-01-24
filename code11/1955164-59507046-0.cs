        sdk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        sdk.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8052));
        sdk.Listen(10);
        Socket accepted = sdk.Accept();
        Buffer = new byte[accepted.SendBufferSize];
        while (true)
        {
            // begin reading continually from the socket
            // Socket::Receive() will block until it gets some data
            // Exception handling required here for when client closes connection
            int bytesRead = accepted.Receive(Buffer);
            byte[] formatted = new byte[bytesRead];
            for (int i = 0; i < bytesRead; i++)
            {
                formatted[i] = Buffer[i];
            }
            Debug.Log("\t Server" + "\n");
            string stradata = Encoding.ASCII.GetString(formatted);
            Debug.Log("-->" + "" + stradata + "\n\n");
            // Need to add some exit logic here eg,
            if(stradata.Contains("EXIT"))
                break;
        }
        sdk.Close(); 
        accepted.Close();
