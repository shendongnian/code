    public class SomeClass
    {
      private DirectoryEntry _root;
      private DirectorySearcher _searcher;
    
      public SomeClass()
      {
        _root = new DirectoryEntry("ldap://bla");
        var temp = new DirectorySearcher(_root);
        temp.PageSize = int.MaxValue;
        temp.SizeLimit = int.MaxValue;
        _searcher = temp;
      }
    }
