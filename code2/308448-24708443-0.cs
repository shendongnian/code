    //Define path
    //This path uses the full path of user authentication
    String path = string.Format("WinNT://{0}/{1},user", server_address, username);
    DirectoryEntry deBase = null;
    try
    {
        //Try to connect with secure connection
        deBase = new DirectoryEntry(_ldapBase, _username, _passwd, AuthenticationTypes.Secure);
        //Connection test
        //After test define the deBase with the parent of user (root container)
        object nativeObject = _deRoot.NativeObject;
        _deRoot = _deRoot.Parent;
    }
    catch (Exception ex)
    {
        //If an error occurred try without Secure Connection
        try
        {
            _deRoot = new DirectoryEntry(_ldapBase, _username, _passwd);
            //Connection test
            //After test define the deBase with the parent of user (root container)
            object nativeObject = _deRoot.NativeObject;
            _deRoot = _deRoot.Parent;
            nativeObject = _deRoot.NativeObject;
        }
        catch (Exception ex2)
        {
            //If an error occurred throw the error
            throw ex2;
        }
    }
