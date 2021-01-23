  Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application(); 
  Microsoft.Office.Interop.Outlook._NameSpace ns = app.GetNamespace("MAPI");
        Microsoft.Office.Interop.Outlook.MAPIFolder inboxFolder = null;
  inboxFolder = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
            inboxFolder.Items.Sort("[ReceivedTime]", false);
            foreach (var item in inboxFolder.Items)
            {
                // ITEMS ARE NOT SORTED
            }
To make it work you must copy them in different list and then sort. The example below will work.
     Outlook.Application app = new Outlook.Application();
     Outlook.NameSpace outlookNs = app.GetNamespace("MAPI");
     Outlook.MAPIFolder emailFolder =        outlookNs.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
     Outlook.Items myItems = emailFolder.Items;
     myItems.Sort("[ReceivedTime]", false);
          
      foreach (var item in myItems)
      {
           var itemObj = item as MailItem;
           if (itemObj != null)
           {
                       // This time it will work
           }
      }
