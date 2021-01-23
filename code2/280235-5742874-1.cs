    private TcpListener listener;
    public void Start()
    {          
        listener = new TcpListener(IPAddress.Any, 10250);
        listener.Start();
        Console.WriteLine("Listening...");
        StartAccept();
       
    }
    private void StartAccept()
    {
        listener.BeginAcceptTcpClient(HandleAsyncConnection, listener);
    }
    private void HandleAsyncConnection(IAsyncResult res)
    {
        StartAccept(); //listen for new connections again
        TcpClient client = listener.EndAcceptTcpClient(res);
        //proceed
        
    }
