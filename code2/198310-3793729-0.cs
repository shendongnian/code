    public IList<Folder> GetFolderList(Object pClient, IEntitlementService pService) {
     if (pService.IsEntitledToAccess(this, pClient) {
      return folderList;
     } else {
      throw new AccessNotGrantedException("...");
     }
    }
