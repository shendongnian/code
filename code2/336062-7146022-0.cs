    public static string GetMsiInfo( string msiPath, string Info)
    {
       string retVal = string.Empty;
    
       Type classType = Type.GetTypeFromProgID( “WindowsInstaller.Installer” );
       Object installerObj = Activator.CreateInstance( classType );
       Installer installer = installerObj as Installer;
    
       // Open msi file
       Database db = installer.OpenDatabase( msiPath, 0 );
    
       // Fetch the property
       string sql = String.Format(“SELECT Value FROM Property WHERE Property=’{0}’”, Info);
       View view = database.OpenView( sql );
       view.Execute( null );
    
       // Read in the record
       Record rec = view.Fetch();
       if ( rec != null )
          retVal = rec.get_StringData( 1 );
    
       return retVal;
    }
