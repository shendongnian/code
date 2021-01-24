    var service = OAuthConnectPost();
    service.Credentials = new WebCredentials(EmailBox, EmailPass, EmailDomain);
    FolderId rootFolderId = new FolderId(WellKnownFolderName.Inbox);
    ItemView view = new ItemView(500);
    FindItemsResults<Item> findResults = service.FindItems(rootFolderId, view); 
