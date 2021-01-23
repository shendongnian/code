    IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 9999);
    byte[] data = new byte[0];
    string message = "";
    
    using (UdpClient listener = new UdpClient(endPoint))
    {
        while(true)
        {
            if(listener.Available > 0)
            {
                data = listener.Receive(ref endPoint);
                message = Encoding.ASCII.GetString(data);
            }
            // Do something else here.
            // ...
            //
            // It's also probably a good idea to sleep briefly to ensure 
            // you've processed any Thread.Abort() exceptions.
            //
            // System.Threading.Thread.Sleep(10);
        }
    }
