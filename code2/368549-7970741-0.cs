    public MailMessage CreateEmail(Email email)
    {
        db.Emails.Add(email);
        db.SaveChanges();
        db.Entry(email).Reference(e => e.FromEmailAddress).Load();
        db.Entry(email).Reference(e => e.ToEmailAddress).Load();
        //...
    }
