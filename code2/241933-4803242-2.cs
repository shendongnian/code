    IEnumerable<bool> StatusChecks()
    {
        // Do stuff
        yield return GetStatus( ref status );
        // Do stuff
        yield return GetStatus( ref status );
        // Do stuff
        yield return GetStatus( ref status );
    }
    
    bool Enable()
    {
        foreach ( var b in StatusChecks() )
        {
            if ( !b )
            {	
                return false;
            } 
        }
        return true;
    }
