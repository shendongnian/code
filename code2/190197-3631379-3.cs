    foreach (string svrName in args)
    {
       try
       {
          System.Net.Sockets.TcpClient tcp = new System.Net.Sockets.TcpClient(svrName, 1433);
          if (tcp.Connected)
             Console.WriteLine("Opened connection to {0}", svrName);
          else
             Console.WriteLine("{0} not connected", svrName);
          tcp.Close();
       }
       catch (Exception ex)
       {
          Console.WriteLine("Error connecting to {0}: {1}", svrName, ex.Message);
       }
    }
