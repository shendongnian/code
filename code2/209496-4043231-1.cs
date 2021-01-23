    static IEnumerable<object> Iterator( ExAPI api )
    {
       bool abort = false;
        for( int i = 0; !abort; ++i )
        {
            object obj;
            if( TryGetObject( api, i, out obj ) )
            {
                yield return obj;
            }
            else
            {
                abort = true;
            }
        }
    }
    
