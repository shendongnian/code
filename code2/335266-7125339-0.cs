    private MailMessage GetMailMessageFromMailItem(Data.SystemX.MailItem mailItem)
    {
        bool success = false;
        var msg = new MailMessage();
        try
        {
            // Code to build up bits of the message
            success = true;
            return msg;
        }
        finally
        {
            if (!success)
            {
                msg.Dispose();
            }
        }
    }
