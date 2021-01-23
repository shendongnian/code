    while(true)
    {
      DataMessage message = null;
    
      lock(NetworkingClient.DataMessages.SyncRoot) {
           if(NetworkingClient.DataMessages.Count > 0) {
              message = NetworkingClient.DataMessages.Dequeue();
           } else {
             break;
           }
        }
        // .. rest of your code
    }
