    protected override void OnStart(string[] args)
    {
        Start();
        
        // This method finishes immediately (or at least after your first 
        // 'await' in the Start() method. That does not mean Start() runs 
        // on another thread however.
    }
    private async Task Start()
    {
        try
        {
            //initialization things
            ...
            ...
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            while(true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                ...
            }
            ...   
        }
        catch (Exception ex)
        {
            // TODO: LOG! And probably stop the service too.
        } 
    }
