    static void TestConn(string server)
    {
       try
       {
          using (System.Net.Sockets.TcpClient tcpSocket = new System.Net.Sockets.TcpClient())
          {
             IAsyncResult async = tcpSocket.BeginConnect(server, 1433, ConnectCallback, null);
             DateTime startTime = DateTime.Now;
             do
             {
                System.Threading.Thread.Sleep(500);
                if (async.IsCompleted) break;
             } while (DateTime.Now.Subtract(startTime).TotalSeconds < 5);
             if (async.IsCompleted)
             {
                tcpSocket.EndConnect(async);
                Console.WriteLine("Connection succeeded");
             }
             tcpSocket.Close();
             if (!async.IsCompleted)
             {
                Console.WriteLine("Server did not respond");
                return;
             }
          }
       }
       catch(System.Net.Sockets.SocketException ex)
       {
          Console.WriteLine(ex.Message);
       }
    }
