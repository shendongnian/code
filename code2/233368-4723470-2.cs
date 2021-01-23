    using(Imap imap = new Imap())
    {
        imap.Connect("imap.server.com");
        imap.Login("user", "password");
     
        imap.SelectInbox();
        List<long> uidList = imap.Search(Flag.Unseen);
        foreach (long uid in uidList)
        {
            IMail email = new MailBuilder()
                .CreateFromEml(imap.GetMessageByUID(uid));
            Console.WriteLine(email.Subject);
            Console.WriteLine(email.Attachments.Count);
        }
        imap.Close();
    }
