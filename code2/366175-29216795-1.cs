    var view = new FolderView(1);
    view.Traversal = FolderTraversal.Deep;
    var filter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "Rejected");
    var results = Service.FindFolders(WellKnownFolderName.Root, filter, view);
    if (results.TotalCount < 1)
        throw new Exception("Cannot find Rejected folder");
    if (results.TotalCount > 1)
        throw new Exception("Multiple Rejected folders");
    Rejected = Folder.Bind(Service, results.Folders.Single().Id);
