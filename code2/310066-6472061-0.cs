    var input = SomeLongString;
    // may as well initialize the capacity as well
    // as the length will be 1 to 1 with the unprocessed input.
    var sb = new StringBuilder( input.Length );
    foreach( char c in input )
    {
        sb.Append( Process( c ) );
    }
