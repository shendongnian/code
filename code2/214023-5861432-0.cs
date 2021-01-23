    public void Starter(){
        StateObject state = new StateObject();
        //set any values in state you need here.
        //create a new socket and start listening on the loopback address.
        Socket lSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        lSock.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        EndPoint ncEP = new IPEndPoint(IPAddress.Any, 0);
        lSock.BeginReceiveFrom(state.buffer, 0, state.buffer.Length, SocketFlags.None, ref ncEP,    DoReceiveFrom, state);
        //create a new socket and start listening on each IPAddress in the Dns host.
        foreach(IPAddress addr in Dns.GetHostEntry(Dns.GetHostName()).AddressList){
            if(addr.AddressFamily != AddressFamily.InterNetwork) continue; //Skip all but IPv4 addresses.
            Socket s = new Socket(addr.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            s.Bind(new IPEndPoint(addr, 12345));
            EndPoint newClientEP = new IPEndPoint(IPAddress.Any, 0);
      
            StateObject objState = new StateObject();
            s.BeginReceiveFrom(objState.buffer, 0, objState.buffer.length, SocketFlags.None, ref newClientEP, DoReceiveFrom, objState);
         }
    } 
