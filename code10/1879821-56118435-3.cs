    bool sendCalled = false;
    
    try
    {
        SendData("!GetLocation!");
        sendCalled = true;
        string data = GetData();
    }
    catch (System.IO.IOException ex)
    {
        if (sendCalled)
        {
         // GetData error
        }
        else
        {
         // SendData error
        }
    }
