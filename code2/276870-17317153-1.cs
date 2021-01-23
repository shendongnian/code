    MAPIFolder mailsFromThisFolder;
    
    MAPIFolder mainFolder = oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
    foreach (MAPIFolder folder in mainFolder.Folders)
    {
        GetFolders(folder);
    }
    
    public void GetFolders(MAPIFolder folder)
    {
        if (folder.Folders.Count == 0)
        {
                if (folder.Name == "Folder Name")
                {
                    Console.WriteLine(m.FullFolderPath);
                    mailsFromThisFolder = folder;
                }
        }
        else
        {
             foreach (MAPIFolder subFolder in folder.Folders)
             {
                  GetFolders(subFolder);
             }
        }
    }
    Outlook.Items items = mailsFromThisFolder.Items;
    foreach (Outlook.MailItem mail in items)
    {
        //do someting
    }
