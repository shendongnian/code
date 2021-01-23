    public override void
        Uninstall(System.Collections.
        IDictionary savedState)
    {
        IsolatedStorageFile isf =
        	IsolatedStorageFile.GetStore(
        	IsolatedStorageScope.Assembly |
        	IsolatedStorageScope.User,
        	(Type)null,
        	(Type)null);
        isf.Remove();
        base.Uninstall(savedState);
    }
