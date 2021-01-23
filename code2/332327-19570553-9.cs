    [Test]
    public void GetAllEmails()
    {
        var mailRepository = new MailRepository("imap.gmail.com", 993, true, "YOUREMAILHERE@gmail.com", "YOURPASSWORDHERE");
        var allEmails = mailRepository.GetAllMails();
    
        foreach(var email in allEmails)
        {
            Console.WriteLine(email);
        }
    
        Assert.IsTrue(allEmails.ToList().Any());
    }
