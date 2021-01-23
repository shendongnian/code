    public SomeClass()
    {
        _root = new DirectoryEntry("ldap://bla");
        try
        {
            _searcher = new DirectorySearcher(_root);
            _searcher.PageSize = 1000;
            _searcher.SizeLimit = 1000;
        }
        catch
        {
             if (_searcher != null)
             {
                 _searcher.Dispose();
             }
             throw;
        }
