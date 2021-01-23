    bool IsServiceAlive()
    {
       bool connected = false;  //bool is always initialized to false, but for readability in this context
    
       try
       {
          //Some check
          Service.Connect();
          connected = true;
       }
       catch (CouldNotConnectToSomeServiceException)
       {
          //Do what you need to do
       }
    
       return connected;
    }
    //or
    void IsServiceAlive()
    {
       try
       {
          //Some check
          Service.Connect();
       }
       catch (CouldNotConnectToSomeServiceException)
       {
          //Do what you need to do
          throw;
       }
    }
    static void Main(string[] args)
    {
        //sample 1
        if (IsServiceAlive())
        {
           //do something
        }
        //sample 2
        try
        {
           if (IsServiceAlive())
           {
              //do something
           }
        }
        catch (CouldNotConnectToSomeServiceException)
        {
           //handle here
        }
        //sample 3
        try
        {
           IsServiceAlive();
           //work
        }
        catch (CouldNotConnectToSomeServiceException)
        {
           //handle here
        }
    }
