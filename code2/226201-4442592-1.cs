    void authenticate ( String username, String password )
    {
         if ( invalid_password(password) ) {
             throw new LoginFailed();
         }
         // ... perform authentication ...
    }
