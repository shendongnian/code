    SocketAsyncEventArgs args;
    switch (packet)
            {
                case PacketID.KeepAlive:
                    args.SetBuffer(new byte[4], 0, 4);
                    args.Completed += new EventHandler<SocketAsyncEventArgs>(HandleKeepAlive);
                    e.ConnectSocket.ReceiveAsync(args);
                    break;
                default:
                    RelinkPacketManager();
                    break;
        }
