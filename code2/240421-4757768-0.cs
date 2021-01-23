    void foo( params string[ ] parameters )
    {
        StringBuilder sb = new StringBuilder( );
        
        foreach ( string parameter in parameters )
        {
            sb.Append( parameter );
            sb.Append( " " );
        }
  
        tsk.run( sb.ToString( ) );
    }
