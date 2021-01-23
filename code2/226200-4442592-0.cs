    bool authenticate ( String username, String password )
    {
         if ( invalid_password(password) ) {
             return (false);
         }
         // ... perform authentication ...
    }
