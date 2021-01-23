    var lines = File.ReadAllLines( path );
    foreach( var line in lines )
    {
        if( line.StartsWith( ";" ) )
        {
            continue;
        }
        else
        {
            // do your stuff
        }
    }
