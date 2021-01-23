    using OpenContactsNet;
    OpenContactsNet.GmailExtract gm = new OpenContactsNet.GmailExtract();
    NetworkCredential nw = new NetworkCredential("sainathsagars@yahoo.com", "");
    OpenContactsNet.MailContactList ml = new OpenContactsNet.MailContactList();
    gm.Extract(nw, out ml);
    // Trying to show something
    StringBuilder sbMessage = new StringBuilder();
    string strcount = (ml.Count + " Contacts : ");
    foreach (MailContact mc in ml)
    {
        sbMessage.Append(mc.Email + "<hr size='1'/>");
    }
