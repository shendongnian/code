    private void DoReceiveFrom(IAsyncResult iar){
    //Get the received message.
    Socket recvSock = (Socket)iar.AsyncState;
    //EndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);
    Socket clientEP = recvSock.EndAccept(iar);
    int msgLen = recvSock.EndReceiveFrom(iar, ref clientEP);
    byte[] localMsg = new byte[msgLen];
    Array.Copy(buffer, localMsg, msgLen);
    
    //Start listening for a new message.
    EndPoint newClientEP = new IPEndPoint(IPAddress.Any, 0);
    udpSock.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref newClientEP, DoReceiveFrom, udpSock);
    //Handle the received message
    /*
    Console.WriteLine("Recieved {0} bytes from {1}:{2} to {3}:{4}",
                      msgLen,
                      ((IPEndPoint)recvSock.RemoteEndPoint).Address,
                      ((IPEndPoint)recvSock.RemoteEndPoint).Port,
                      ((IPEndPoint)recvSock.LocalEndPoint).Address,
                      ((IPEndPoint)recvSock.LocalEndPoint).Port);
    //Do other, more interesting, things with the received message.
    */
    Console.WriteLine("Recieved {0} bytes from {1}:{2} to {3}",
                      msgLen,
                      ((IPEndPoint)recvSock.RemoteEndPoint).Address,
                      ((IPEndPoint)recvSock.RemoteEndPoint).Port,
                      clientEP.RemoteEP.ToString();
     }
