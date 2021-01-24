    KillSingleInstance(10001);
    public void KillSingleInstance(int port)
    {
        List<byte> ip = new List<byte>();
        ip.Add(192);
        ip.Add(168);
        ip.Add(1);
        ip.Add(4);
        IPAddress ipAddress = new IPAddress(ip.ToArray());
        IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
        
        Socket sender = new Socket(ipAddress.AddressFamily,  
            SocketType.Stream, ProtocolType.Tcp); 
        sender.Connect(remoteEP);
        byte[] msg = Encoding.ASCII.GetBytes("quit\n"); 
        sender.Send(msg);
        sender.Shutdown(SocketShutdown.Both);  
        sender.Close();
    }
