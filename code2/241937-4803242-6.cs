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
                Trace.WriteLine("Error");                       
                return false;
            } 
        }
        return true;
    }
