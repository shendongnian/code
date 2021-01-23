    private static void SearchItems()
    {
        ExtendedPropertyDefinition allFoldersType = 
            new ExtendedPropertyDefinition(13825, MapiPropertyType.Integer);
        FolderId rootFolderId = new FolderId(WellKnownFolderName.Root);
        FolderView folderView = new FolderView(1000);
        folderView.Traversal = FolderTraversal.Shallow;
        SearchFilter searchFilter1 = new SearchFilter.IsEqualTo(allFoldersType, "2");
        SearchFilter searchFilter2 = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "allitems");
        
        SearchFilter.SearchFilterCollection searchFilterCollection = 
            new SearchFilter.SearchFilterCollection(LogicalOperator.And);
        searchFilterCollection.Add(searchFilter1);
        searchFilterCollection.Add(searchFilter2);
        FindFoldersResults findFoldersResults = 
            _service.FindFolders(rootFolderId, searchFilterCollection, folderView);
        if (findFoldersResults.Folders.Count > 0)
        {
            Folder allItemsFolder = findFoldersResults.Folders[0];
            Console.WriteLine("Folder:\t" + allItemsFolder.DisplayName);
            ItemView iv = new ItemView(1000);
            FindItemsResults<Item> findResults = 
                allItemsFolder.FindItems("System.Message.DateReceived:01/01/2011..01/31/2011", iv);
            foreach (Item item in findResults)
            {
                Console.WriteLine("Subject:\t" + item.Subject);
                Console.WriteLine("Received At:\t\t" + item.DateTimeReceived.ToString("dd MMMM yyyy"));
                Console.WriteLine("Is New:\t\t" + item.IsNew.ToString());
                Console.WriteLine("Has Attachments:\t\t" + item.HasAttachments.ToString());
                Console.WriteLine();
            }
        }
        Console.WriteLine("Press Enter to continue");
        Console.ReadLine();
    }
