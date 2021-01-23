    public static void Run( Action a ) {
        if ( !_uiDispatcher.CheckAccess() ) {
            _uiDispatcher.BeginInvoke( a );
        }
        else {
            a();
        }
    }
