    private readonly object sendSyncRoot = new object();
    private readonly object receiveSyncRoot = new object();
    private void ReceiveCallback(IAsyncResult ar)
    {
        StateObject state = (StateObject)ar.AsyncState;
        Socket client = state.workSocket;
        lock (receiveSyncRoot)
        {
            int bytesRead = client.EndReceive(ar);
            // do some work
            // Kick off socket to receive async again.
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
        }
    }
    // This is commonly called by another thread
    public void SendMessage(string cmdName, Object data)
    {
        lock (sendSyncRoot)
            client.Send(arrayofdata, 0, arraylength, 0);
    }
