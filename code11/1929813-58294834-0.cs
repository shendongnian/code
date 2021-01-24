    public static void Android()
    {
        NetworkStream networkStream_App;
        
        // Buffer for reading data
        byte[] bytes = new byte[1024];
        string data = null;
        int port = 1010;
        //Replace IP with the IP of your C# server
        IPAddress ipAddress = IPAddress.Parse("192.168.43.153");
        TcpListener tcpListener_App = new TcpListener(ipAddress, port);
        tcpListener_App.Start();
        Console.WriteLine("The Server has started on port 1010");
        int msg;
        while (true)
        {
            TcpClient client = tcpListener_App.AcceptTcpClient();
            try
            {
                Console.WriteLine("App-Client connected");
                networkStream_App = client.GetStream();
                while ((msg = networkStream_App.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = Encoding.ASCII.GetString(bytes, 0, msg);
                    if (data.Equals("CoordRequest"))
                    {
                        System.Threading.Thread.Sleep(3000);
                        Console.WriteLine(data);
                        //Send coordinates to App
                        string message = "Test";
                        byte[] msgToClient = Encoding.ASCII.GetBytes(message + "\r\n");
                        networkStream_App.Write(msgToClient, 0, msgToClient.Length);
                        Console.WriteLine(message);
                    }
                }
                networkStream_App.Close();
                tcpListener_App.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
