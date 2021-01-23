    private IObservable<RemoteData> GetRemoteDataAsync()
    {
        return Observable.Defer(() => 
        {
            UdpClient receiverUDP = new UdpClient();
            receiverUDP.Client.SetSocketOption(SocketOptionLevel.Socket, 
                SocketOptionName.ReuseAddress, true);
            receiverUDP.EnableBroadcast = true;
            receiverUDP.Client.ExclusiveAddressUse = false;
            receiverUDP.Client.Bind(new IPEndPoint(IPAddress.Any, 1234));
    
            IPEndPoint ep = null;
            return Observable.FromAsyncPattern<byte[]>(
                       receiverUDP.BeginReceive, 
                       (i) => receiverUDP.EndReceive(i, ref ep)
                   )()
                   .Select(bytes => new RemoteData(bytes, ep));
        });
    }
