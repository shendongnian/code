    // you'll need access to the namespace namespace System.Security.Permissions
    public bool HasAccess( string path , FileIOPermissionAccess accessDesired )
    {
      bool isGranted ;
      try
      {
        FileIOPermission permission = new FileIOPermission( accessDesired , path ) ;
        permission.Demand() ;
        isGranted = true ;
      }
      catch
      {
        isGranted = false ;
      }
      return isGranted ;
    }
