    void Page_Load( ... ) 
    {
        if ( this.Context.User != null &&
             !this.Context.User.IsInRole( "FileDeny" )
            )
           Response.Redirect( FormsAuthentication.LoginUrl );
