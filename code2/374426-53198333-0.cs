    private void ReceiveUdp()
    {
        while (IsRunning)
        {
            var packet = RavelNet.CreatePacket();
            _count = RnetSocket.ReceiveFrom(packet.Data.Array, ref packet.RemoteEp);
            //I am storing the endpoint in my packet but you can do packet.RemotEp.GetHashCode(); will return an integer identifier
            packet.Data.Ptr = _count;
            packet.ReadHeader();
            lock (_inProcess)
                _inProcess.Enqueue(packet);
        }
    }
