    void Receive(object sender, SocketAsyncEventArgs e)
    {
        if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
        {
            var data = PacMan<MessageHeader>.Unpack(e.Buffer);
            if (data.Type == Message.Trade)
            {
                e.SetBuffer(orderBuffer, 0, orderBuffer.Length);
                e.AcceptSocket.Receive(e.Buffer);
                Orders.Enqueue(e.Buffer.ToArray());
            }
            else
            {
                SetBuffer(e, data.Size);
                e.AcceptSocket.Receive(e.Buffer);
                AddNews(e.Buffer.ToArray());
            }
            e.SetBuffer(headerBuffer, 0, headerBuffer.Length);
            if (!OPTstarted)
            {
                orderProcessTimer.Start();
                OPTstarted = true;
            }
            if (!e.AcceptSocket.ReceiveAsync(e)) Receive(null, e);
        }
        else Disconnect4mServer(null);
    }
