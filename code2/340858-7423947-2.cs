    //Client uses as receive udp client
    UdpClient Client = new UdpClient(Port);
    try
    {
         Client.BeginReceive(new AsyncCallback(recv), null);
    }
    catch(Exception e)
    {
         MessageBox.Show(e.ToString());
    }
    //CallBack
    private void recv(IAsyncResult res)
    {
        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 8000);
        byte[] received = Client.EndReceive(res, ref RemoteIpEndPoint);
        //Process codes
        
        MessageBox.Show(Encoding.UTF8.GetString(received));
        Client.BeginReceive(new AsyncCallback(recv), null);
    }
