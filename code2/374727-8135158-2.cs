    public ReceiptStatus Receive(INotification _message)
    {
        if (_message is CheckDatabaseIsSetupNotification)
        {
             var message = _message as CheckDatabaseIsSetupNotification;
             if (connect_to(message.DatabaseName, message.Server, Message.Username, message.Password, message.UseIntergratedSecurity))
                return ReceiptStatus.OK;
             else
                return ReceiptStatus.Fail;
        }
        return ReceiptStatus.NotProcessed;
    }
