    private void InitializeConnection()
    {
        // Parse the IP address
        
        string ipAdress = "XXX.XXX.XXX.XXX";
        ipAddr = IPAddress.Parse(ipAdress);
        // Start a new TCP connections to the chat server
        tcpServer = new TcpClient();
        try
        {
            tcpServer.Connect(ipAddr, 2002);
            swSender = new StreamWriter(tcpServer.GetStream());
            
            // Start the thread for receiving messages and further communication
            thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
            thrMessaging.Start();
            Connected=true;
        }
            catch (Exception e2)
            {
                MessageBox.Show(e2.ToString());
            }
        }
    }
