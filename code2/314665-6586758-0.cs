    interface FilesystemVistor
    {
      void Visit (FilesystemItem item);
    }
    interface FilesystemItem
    {
      void Accept(FilesystemVistor visitor);
      string Name;
    }
    
    class Directory : FilesystemItem
    {
      private FilesystemItem[] _children;
      public void Accept(FilesystemVistor visitor) {
        visitor.Visit(this);
        foreach(FilesystemItem item in _children)
        {
          visitor.Visit(item);
        }
      }
    }
    class File : FilesystemItem
    {
      public void Accept(FilesystemVistor visitor) {
        visitor.Visit(this);
      }
    }
    
    class FilesystemSearcher : FilesystemVistor
    {
      private List<string> _results;
      public void Visit(FilesystemItem item) {
        if (item.Name == "Foo") { _results.Add(item.Name); }
      }
    }
