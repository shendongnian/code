            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            string welcome = "Hello, are you there?";
            data = Encoding.ASCII.GetBytes(welcome);
            server.ReceiveTimeout = 10000; //1second timeout
            int rslt =  server.SendTo(data, data.Length, SocketFlags.None, ipep);
            data = new byte[1024];
            int recv = 0;
            do
            {
                try
                {
                    Console.WriteLine("Start time: " + DateTime.Now.ToString());
                    recv = server.Receive(data); //the code will be stoped hier untill the time out is passed
                }
                catch {  }
            } while (true); //carefoul! infinite loop!
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
            Console.WriteLine("Stopping client");
            server.Close();
