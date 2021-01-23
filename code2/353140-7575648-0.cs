      private UdpClient udpClientR;
      private Thread t1;
      void StartUpd()
      {
         udpClientR = new UdpClient();
         udpClientR.Connect(Settings.rxIPAddress, PORT_RX_LOCAL);
         t1 = new Thread(() => UdpReceiveThread(PORT_RX_REMOTE)) { IsBackground = true };
         t1.Start();
         // Give it some time here to startup, incase you call StopUpd too soon
         Thread.Sleep(1000);
      }
      private void StopUpd()
      {
         udpClientR.Close();
         // Wait for the thread to exit.  Calling Close above should stop any
         // Read block you have in the UdpReceiveThread function.  Once the
         // thread dies, you can safely assume its closed and can call StartUpd again
         while (t1.IsAlive) { Thread.Sleep(10); }
      }
