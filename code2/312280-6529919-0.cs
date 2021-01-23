    void MyApplication_NewMailEx(string anEntryID)
    {
      Outlook.NameSpace namespace = this.GetNamespace("MAPI");  
      Outlook.MAPIFolder folder = this.Session.GetDefaultFolder( Outlook.OlDefaultFolders.olFolderInbox );
      Outlook.MailItem mailItem = (Outlook.MailItem) outlookNS.GetItemFromID( anEntryID, folder.StoreID );
    
      // ... process the mail item
    }
