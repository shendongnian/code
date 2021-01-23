    public class FolderVM
    {
      public string Name {get; private set;}      
      public IEnumerable<FolderVM> Folders { get; private set; }
      public IEnumerable<ItemVM> Items { get; private set; }
      public FolderVM(Folder folder)
      {
        Name = folder.Name;
        Folders = folder.ChildFolders.Select(f=> new FolderVM(f));
        Items = folder.Items.Select(i=> new ItemVM(i));
      }
    }
