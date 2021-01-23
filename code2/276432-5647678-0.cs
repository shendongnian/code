      public static void Main()
      {
       Advertise server = new Advertise();
      }
      public Advertise()
      {
       Thread advert = new Thread(new ThreadStart(sendPackets));
       advert.IsBackground = true;
       advert.Start();
       Console.Write("Press Enter to stop");
       string data = Console.ReadLine();
      }
      void sendPackets()
      {
       Socket sock = new Socket(AddressFamily.InterNetwork,
               SocketType.Dgram, ProtocolType.Udp);
       sock.SetSocketOption(SocketOptionLevel.Socket,
                  SocketOptionName.Broadcast, 1);
       IPEndPoint iep = new IPEndPoint(IPAddress.Broadcast, 9050);
       string hostname = Dns.GetHostName();
       byte[] data = Encoding.ASCII.GetBytes(hostname);
       while (true)
       {
         sock.SendTo(data, iep);
         Thread.Sleep(60000);
       }
      }
