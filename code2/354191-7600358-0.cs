    using( TextReader reader = new StreamReader( 
             new IsolatedStorageFileStream( "myFile.txt", System.IO.FileMode.Open, 
               IsolatedStorageFile.GetUserStoreForApplication() ) ) {
    
        string line = reader.ReadLine(); // first line, discard
        line = reader.ReadLine();        // second line, discard
        line = reader.ReadLine();        // third line, read the variable value
    }
