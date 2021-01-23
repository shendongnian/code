    ServiceClient client = new ServiceClient();
    try
    {
      foreach(...)
      {
        ...
        //Current batch count is 1,000
        if (currentBatchCount == amountPerBatch)
        {
            currentBatchCount = 0;
            client.Close();
            client = new ServiceClient();
        }
        ...
      }
    }
    finally
    {
      if(client.State == CommunicationState.Faulted)
        client.Abort();
      else
        client.Close();
    }
