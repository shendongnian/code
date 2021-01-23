    while(retryCount < MAX_RETRY && !success)
    {
       try
       {
          //do stuff , calling web service
          success = true;
       }
       catch
       {
          retryCount++
          success = false;
       }
    }
