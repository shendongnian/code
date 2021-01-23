    public static void GenerateEmail(string emailTo, string ccTo, string subject, string body)
    {
        var objOutlook = new Application();
        var mailItem = (MailItem)(objOutlook.CreateItem(OlItemType.olMailItem));        
        mailItem.To = emailTo;          
        mailItem.CC = ccTo;
        mailItem.Subject = subject;
        mailItem.Display(mailItem);
        mailItem.HTMLBody = body + mailItem.HTMLBody;
    }
