    public MailMessage CreateMessage(string fromAddress, string recipient)
    {
        MailMessage message = new MailMessage(fromAddress, recipient);
        try {
            message.Subject = subject;
            message.Body = body;
            return message;
        }
        catch {
            if (message != null) {
                message.Dispose();
            }
            throw;
        }
    }
