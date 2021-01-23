    if (!ServiceLocator.IsWcfStarted())
    {
        WriteEventlog("First instance of WCF Client... starting WCF host.")
        ServiceLocator.StartWcfHost();
        int timeout=0;
        while (!ServiceLocator.IsWcfStarted()) 
        {
          timeout++;
          if(timeout> MAX_RETRY)
          {
           //show message that probably wcf host is not available, end the client
           ....
          }
        }
    }
