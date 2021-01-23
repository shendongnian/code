    Dictionary<TcpClient, Thread> _threads = new Dictionary<TcpClient, Thread>();
    object _lockObject = new object();
    
    void AddThread(TcpClient client, Thread thread)
    {
        lock (_lockObject)
        {
            _threads.Add(client, thread);
        }
    }
    
    void RemoveThread(TcpClient client)
    {
        lock (_lockObject)
        {
            _threads.Remove(client);
        }
    
    }
    
    void YourMainMethod()
    {
        this._tcpListener.Start();
    
        while (true)
        {
             //blocks until a client has connected to the server
             TcpClient client = this._tcpListener.AcceptTcpClient();
    
             //create a thread to handle communication 
             //with connected client
             Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientCommunication));
             AddThread(client, clientThread);
             clientThread.Start(client);
        }
    }
    
    
    private void HandleClientCommunication(object client)
    {
        try
        {
            using (TcpClient tcpClient = (TcpClient) client)
            {
                //Do my work
            }
        } catch (Exception)
        {
             // so program doesn't crash
        }
        finally
        {
            RemoveThread((TcpClient)client);
        }
    }
