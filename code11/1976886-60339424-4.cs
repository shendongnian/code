    public Task SendPasswordEmail(string emailId, string link)
    {
        return _emailSender
            .To(emailId)
            .Subject(EmailUtilsConstants.PasswordEmailSubject)
            .Body(EmailUtilsConstants.PasswordEmailText + link)
            .SendAsync();
    }
