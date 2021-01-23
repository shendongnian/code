    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    IPAddress ipAdd = System.Net.IPAddress.Parse(m_ip);
    IPEndPoint remoteEP = new IPEndPoint(ipAdd, m_port);
    
    socket.Connect(remoteEP);
    
    byte[] byData = System.Text.Encoding.ASCII.GetBytes("Message");
    socket.Send(byData);
    
    
    socket.Disconnect(false);
    socket.Close();
