    ServiceClient client = null;
    try
    {
        client = new ServiceClient();
        data = client.GetDirectories(true);
    }
    finally
    {
        if (client != null)
        {
            if (client.State == CommunicationState.Faulted) 
            {
                client.Abort();
            } 
            else 
            {
                client.Close();
            }
        }
    }
