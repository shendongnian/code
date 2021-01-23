    private void ReceiveCallback(IAsyncResult iar)
    {
        IPPacketInformation packetInfo;
        EndPoint remoteEnd = new IPEndPoint(IPAddress.Any, 0);
        SocketFlags flags = SocketFlags.None;
        Socket sock = (Socket) iar.AsyncState;
        int received = sock.EndReceiveMessageFrom(iar, ref flags, ref remoteEnd, out packetInfo);
        Console.WriteLine(
            "{0} bytes received from {1} to {2}",
            received,
            remoteEnd,
            packetInfo.Address
        );
    }
