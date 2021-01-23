    private ISmtpMail _smtpMail;
    public BusinessLogic(ISmtpMail smtpMail)
    {
        _smtpMail = smtpMail;
    }
    public void SomeMethod()
    {
        ...
        _smtpMail.Send();
    }
