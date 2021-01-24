    private bool volatile shouldCancel; //Dirty, but will work on Intel hardware :-)
    public void KeepReceiveingMessages()
    {
        while(true)
        {
            bool signaled = _dataServiceConnected.Waitone(100);
            if (!signaled && shouldCancel) return;
            try
            {
                var buffersize = m_DeviceClientSocket.ReceiveBufferSize;
                byte[] instream = new byte[buffersize];
    
                m_DeviceServerStream.Read(instream, 0, buffersize) //THREAD T1 KEEP WAITING HERE TILL A MESSAGE IS RECEIVED FROM THE SERVER
            }
            catch(Exception e)
            {                       
               _dataServiceConnected.Reset(); //do not try to eneter again till we have a working connection
            }
        }
    }
