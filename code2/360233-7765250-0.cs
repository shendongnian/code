    if ( Dispatcher.Thread.Equals( Thread.CurrentThread ) )
    {
        Action( );
    }
    else
    {
        Dispatcher.Invoke( Action );
    }
