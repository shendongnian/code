    List<string> output = new List<string>();
    
    bool flag = true;
    foreach ( string line in System.IO.File.ReadAllLines( "MyFile.html" )) {
        
        int index = line.IndexOf( "<!--" );
        if ( index > 0 )) {
            output.Add( line.Substring( 0, index ));
            flag = false;
        }
        
        if ( flag ) {
            output.Add( line );
        }
        
        if ( line.Contains( "-->" )) {
           output.Add( line.Substring( line.IndexOf( "-->" ) + 3 )); 
           flag = true;
       }
    }
     
    System.IO.File.WriteAllLines( "MyOutput.html", output ); 
