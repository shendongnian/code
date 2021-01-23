    // Define this globally, on your main thread
    UdpClient listener = null;
    // ...
    // ...
    // Create a new thread and run this code:
    IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 9999);
    byte[] data = new byte[0];
    string message = "";
    
    listener.Client.SendTimeout = 5000;
    listener.Client.ReceiveTimeout = 5000;
    
    listener = new UdpClient(endPoint);
    while(true)
    {
        try
        {
            data = listener.Receive(ref endPoint);
            message = Encoding.ASCII.GetString(data);
        }
        catch(System.Net.Socket.SocketException ex)
        {
            if (ex.ErrorCode != 10060)
            {
                // Handle the error. 10060 is a timeout error, which is expected.
            }
        }
        // Do something else here.
        // ...
        //
        // If your process is eating CPU, you may want to sleep briefly
        // System.Threading.Thread.Sleep(10);
    }
    // ...
    // ...
    // Back on your main thread, when it's exiting, run this code
    // in order to completely kill off the UDP thread you created above:
    listener.Close();
    thread.Close();
    thread.Abort();
    thread.Join(5000);
    thread = null;
