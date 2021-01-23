    while (true)
    {
        try
        {
            if (listener.Available > 0) // Only read if we have some data 
            {                           // queued in the network buffer. 
                byte[] data = listener.Receive(ref groupEP);
    
                IPEndPoint newuser = new IPEndPoint(groupEP.Address, groupEP.Port);
                string sData =  (System.Text.Encoding.ASCII.GetString(data));
            }
        }
        catch (Exception e)
        {
        }
    }
