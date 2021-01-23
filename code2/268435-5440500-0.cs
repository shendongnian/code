    List<string> output = new List<string>();
    
    bool flag = true;
    foreach ( string line in System.IO.File.ReadAllLines( "MyFile.html" )) {
        if ( line.Contains( "<!--" )) {
            flag = false;
        }
        
        if ( flag ) {
            output.Add( line );
        }
        
        if ( line.Contains( "-->" )) {
            flag = true;
       }
    }
     
    System.IO.File.WriteAllLines( "MyOutput.html", output ); 
