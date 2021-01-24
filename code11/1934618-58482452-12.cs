    protected static void OnLogoutResponse( ResponseData data )
        {
             var handler = onLogoutResponse;
             if( handler != null ){
                handler( typeof(DataLogout), data ); // cannot use "this", of course in static context.
             }
        }
