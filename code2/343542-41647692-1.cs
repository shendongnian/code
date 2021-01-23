    public void ToAdmin(Message message, SessionID sessionID)
    {
        if (!authorized)
        {
            message.SetField(new Username("YOUR_USERNAME"));
            message.SetField(new Password("YOUR_PASSWORD"));
            authorized = true;
        }          
        message.SetField(new Account("YOUR_ACCOUNT_NUMBER"));
    }
