    internal MailMessage ConstructTextMailMessage(MailAddress from, MailAddress to, string subject, string body)
    {
        return ConstructTextMailMessage(from.Address, to.Address, subject, body);
    }
    internal MailMessage ConstructTextMailMessage(string from, string to, string subject, string body)
    {
        return new MailMessage(from, to, subject, body);
    }
