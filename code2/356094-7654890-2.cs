    private void AcceptClient(TcpListener tcpListener)
    {
        Task<TcpClient> acceptTcpClientTask = Task.Factory.FromAsync<TcpClient>(tcpListener.BeginAcceptTcpClient, tcpListener.EndAcceptTcpClient, tcpListener);
           
        // This allows us to accept another connection without a loop.
        // Because we are within the ThreadPool, this does not cause a stack overflow.
        acceptTcpClientTask.ContinueWith(antecedent => { OnAcceptConnection(antecedent.Result); AcceptClient(tcpListener); }, TaskContinuationOptions.OnlyOnRanToCompletion);
    }
    private void OnAcceptConnection(TcpClient tcpClient)
    {
        string authority = tcpClient.Client.RemoteEndPoint.ToString(); // Format is: IP:PORT
        // Start a new Task to handle client-server communication
    }
