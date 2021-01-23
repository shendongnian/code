    public void ProcessMessage(Result result)
    {
      // Do something with Result.ReturnedMessage
      result.ReturnedMessage.Process(result.Target);
    }
