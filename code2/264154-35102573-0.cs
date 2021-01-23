    // 1
    while (listening)
    {
        TcpClient client = listener.AcceptTcpClient();
        // Start a thread to handle this client...
        new Thread(() => HandleClient(client)).Start();
    }
    // 2
    while (listening)
    {
        TcpClient client = listener.AcceptTcpClient();
        // Start a task to handle this client...
        Task.Run(() => HandleClient(client));
    }
    // 3
    public async void StartListener() //non blocking listener
    {
        listener = new TcpListener(ipAddress, port);
        listener.Start();
        while (listening)
        {
            TcpClient client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);//non blocking waiting                    
            // We are already in the new task to handle this client...   
            HandleClient(client);
        }
    }
    //... in your code
    StartListener();
    //...
    //use Thread.CurrentThread.ManagedThreadId to check task/thread id to make yourself sure
