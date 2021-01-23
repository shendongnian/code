    const string ISOLATED_FILE_NAME = "MyIsolatedFile.txt";
    
    IsolatedStorageFile isoStore = 
      IsolatedStorageFile.GetStore( IsolatedStorageScope.User 
      | IsolatedStorageScope.Assembly, null, null );
    
    string[] fileNames = isoStore.GetFileNames( ISOLATED_FILE_NAME );
    
    foreach ( string file in fileNames )
    {
        if ( file == ISOLATED_FILE_NAME )
        {
           Debug.WriteLine("The file already exists!");
        }
    }
