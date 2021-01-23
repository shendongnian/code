    var buffer = new byte[65536];
    var s = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Igmp); // filter out non IGMP
    byte[] one = BitConverter.GetBytes(1);
    s.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.148"), 0)); // Which interface to listen on
    s.IOControl(IOControlCode.ReceiveAll, one, one); // enter promiscuous mode
    s.Recieve(buffer); // get yourself some data (BeginRecieve didn't seem to work here)
