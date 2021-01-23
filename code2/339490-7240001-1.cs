    public void OnDataReceived(IAsyncResult asyn)
    {
        BLCommonFunctions.WriteLogger(0, "In :- OnDataReceived", ref swReceivedLogWriter, strLogPath, 0);
    
        try
        {
            SocketPacket client = (SocketPacket)asyn.AsyncState;
    
            int bytesReceived = client.thisSocket.EndReceive(asyn); //Here error is coming
            if (bytesReceived == 0)
            {
              HandleDisconnect(client);
              return;
            }
        }
        catch (Exception err)
        {
           HandleDisconnect(client);
        }
     
        try
        {
            string strHEX = BLCommonFunctions.ByteArrToHex(theSockId.dataBuffer);                    
    
            //do your handling here
        }
        catch (Exception err)
        {
            // Your logic threw an exception. handle it accordinhly
        }
    
        try
        {
           client.thisSocket.BeginRecieve(.. all parameters ..);
        }
        catch (Exception err)
        {
           HandleDisconnect(client);
        }
    }
