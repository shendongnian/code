    private Thread _tcpThread;
    private TcpClient _socketConnection;
    public void Connect()
    {
        if(_socketConnection != null) return;
        try
        {
            _tcpThread = new Thread(ReciveDataClient);
            _tcpThread.IsBackground = true;
            _tcpThread.Start();
        }
        catch (Exception e)
        {
            print("TCP -> Thread error: " + e.Message);
        }
    }
    public void Disconnect()
    {
        if(_socketConnection = null) return;
        _tcpThread.Abort();
    }
    private void ReciveDataClient()
    {
        try
        {
            _socketConnection = new TcpClient("xxx.xxx.xxx.xxx", 54321);
            print(this, "TCP -> Connection Success!");
        }
        catch (Exception e)
        {
            print("TCP -> connection error: " + e.Message)
            return;
        }
    
        try
        {
            while(true)
            {
                // Get a stream object for reading              
                var netstream = _socketConnection.GetStream();
                //Check if still connected                
                if(_socketConnection.Client.Poll(0, SelectMode.SelectRead))
                {
                    byte[] buff = new byte[1];
                    if( _socketConnection.Client.Receive( buff, SocketFlags.Peek ) == 0 )
                    {
                        // Server disconnected or connection lost
                        break;
                    }
                }
                // Check to see if this NetworkStream is readable.
                if(myNetworkStream.CanRead)
                {
                    byte[] myReadBuffer = new byte[BUFFER_SIZE];
                    StringBuilder myCompleteMessage = new StringBuilder();
                    int numberOfBytesRead = 0;
                    int totalBytesReceived = 0;
    
                    // Incoming message may be larger than the buffer size.
                    do
                    {
                        numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);
                        myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));	
                        totalBytesReceived += numberOfBytesRead;		
                    }
                    while(myNetworkStream.DataAvailable);
    
                    // Print out the received message to the console.
                    print("TCP -> Data received:\n" + myCompleteMessage.ToString() + "\n\n" + totalrecbytes + " Bytes");
                }
                else
                {
                    //Prevent a direct loop
                    Thread.Sleep(100);
                }          
            }
    
            print("TCP -> connection was terminated by the server");
        }
        catch(ThreadAbortException)
        {
            print("TCP -> Disconnected");
        }
        catch(Exception e)
        {
            print(e.Message)
        }
        // Clean up
        _socketConnection?.Close();
        _socketConnection?.Dispose();
        _socketConnection = null;
    }
