    private void AcceptCallback(IAsyncResult ar)
    {
        allDone.Set();
    
        Socket serverSocket = (Socket)ar.AsyncState;
        Socket clientSocket = serverSocket.EndAccept(ar);
        serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), serverSocket);
    
        Console.WriteLine("Client Thread #" + Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(100000); <----- All request is stopped, no response returned.
    
        // ....
    }
