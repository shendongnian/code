    List< int > currentTracingPoints = new List<int> ( { 1, 2, 3, 4 } );
    List< int > parts = new List<int> ( { 1, 2, 3 } );
    
    for ( int index = currentTracingPoints.Count-1; index >= 0; index-- )
    {
        if ( !parts.Contains( currentTracingPoints[ index ] ) )
        {
            currentTracingPoints.RemoveAt( index );
        }
    }
