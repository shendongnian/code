            public List<string> getMailboxes(string emailAddress, string emailPassword)
        {
            var client = new ImapClient("imap.gmail.com", 993, true, true);
            if (client.Connect())
            {
                if (client.Login(emailAddress, emailPassword))
                {
                    //get all parent folers
                    var folders = client.Folders;
                    foreach (var parentFolder in folders)
                    {
                        //get parent folder path
                        var parentPath = parentFolder.Path;
    
                        //check if every parent folder has subfolder
                        if (parentFolder.HasChildren)
                        {
                            var subfolders = parentFolder.SubFolders;
                            foreach(var subfolder in subfolders)
                            {
                                var subPath = subfolder.Path;
                            }
                        }
                    }
                }
            }
        }
