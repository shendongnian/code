    Microsoft.Office.Interop.Outlook.Application outlookApp = new 
    Microsoft.Office.Interop.Outlook.Application();
    
    MAPIFolder Folder_Contacts = (MAPIFolder)
    outlookApp.Session.GetDefaultFolder(OlDefaultFolders.olFolderContacts);       
    var filter = String.Format("[FullName] = '{0}'", "Jose da Silva" );
    
    ContactItem contact = (ContactItem)Folder_Contacts.Items.Find(filter);
    
    if (contact != null)
    {
        contact.FullName = "Joao da Silva";
        contact.Email1Address = "joao@silva.com.br";
        contact.Save();
    }
