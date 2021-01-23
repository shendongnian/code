    ReceiveMessageResult r = receiveMessageResponse.ReceiveMessageResult;
    
    if (r.Message.Count < 1)
    {
      Console.WriteLine("Can't find any visible messages.");
    }
