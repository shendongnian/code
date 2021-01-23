    public void OnMessageReceived(QuickFix42.Message message, SessionID sessionID)
    {
      crack (message, sessionID);
    }
    
    public override void onMessage(QuickFix42.ExecutionReport message, SessionID sessionID)
    {
       ...
    }
    
    public override void onMessage(QuickFix42.OrderCancelReject message, SessionID sessionID)
    {
       ...
    }
