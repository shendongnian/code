    try {
        clientSocket.Connect(localEndPoint);
        statusChanged?.Invoke(ConnStatus.CONNECTED);
        while(runThread){
            // Send messages in queue
            string RX = String.Empty;
            //READ from Socket
            //perform some basic checks if needed
            messageReceived?.Invoke(RX);
        }
        statusChanged?.Invoke(ConnStatus.DISCONNECTED);
    catch {
        statusChanged?.Invoke(ConnStatus.FAULTED);
    }
    finally {
        //perform some cleanup
    }
 
