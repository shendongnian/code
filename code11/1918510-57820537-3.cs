    public abstract class TreeItem
    {
      public TreeItem(String name)
      {
        this.Name = name;
      }
      public string Name { get; set; }
    }
    
    public class Folder : TreeItem
    {
      public Folder(string name) : base(name)
      {
      }
      public List<TreeItem> ChildItems { get; set; } = new List<TreeItem>();
    }
    
    public class Session : TreeItem
    {
      public Session(string name) : base(name)
      {
      }
    }
