    public void OnMessageReceived(QuickFix42.Message message)
    {
        if (message == null)
          throw new ArgumentNullException("message");
          
        message.Process();
    }
