    public void ToAdmin(Message message, SessionID sessionID)
    {
        if (message.GetType() == typeof(QuickFix.FIX44.Logon))
            {
                message.SetField(new Username("YOUR_USERNAME"));
                message.SetField(new Password("YOUR_PASSEORD"));                             
            }          
        message.SetField(new QuickFix.Fields.Account("YOUR_ACCOUNT_NUMBER"));
    }
