    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
       this.Application.NewMailEx += new Outlook.ApplicationEvents_11_NewMailExEventHandler(olApp_NewMail);
    }
    
    private void olApp_NewMail(String entryIDCollection)
    {
       Outlook.NameSpace outlookNS = this.Application.GetNamespace("MAPI");
       Outlook.MAPIFolder mFolder = this.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
       Outlook.MailItem mail;
    
       try
       {
          mail = (Outlook.MailItem)outlookNS.GetItemFromID(entryIDCollection, Type.Missing);
          if (mailItem.Subject.StartsWith("ABCDE"))
          {
             mailItem.BodyFormat = OlBodyFormat.olFormatHTML;
             mailItem.HTMLBody = "<html><body>Click <a href='www.google.com'>here</a>.<br><br></body></html>" + mailItem.HTMLBody;
             mailItem.Save();
          }
       }
       catch
       {}
    }
