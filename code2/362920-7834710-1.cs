    if(Monitor.TryEnter(objectLock, 250))//Don't wait more than 250ms
    {
      try
      {
        //do something
      }
      finally
      {
        Monitor.Exit(objectLock);
      }
    }
    else
    {
      //fallback code
    }
