    //set Server
            ExchangeService server = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            server.UseDefaultCredentials = true;
            string configUrl = @"https://yourServerAddress.asmx";
            server.Url = new Uri(configUrl);
            //SetView
            FolderView view = new FolderView(100);
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
            view.PropertySet.Add(FolderSchema.DisplayName);
            view.Traversal = FolderTraversal.Deep;
            FindFoldersResults findFolderResults = server.FindFolders(WellKnownFolderName.Root, view);
            //find specific folder
            foreach(Folder f in findFolderResults)
            {
                //show folderId of the folder "test"
                if (f.DisplayName == "Test")
                    Console.WriteLine(f.Id);
            }
