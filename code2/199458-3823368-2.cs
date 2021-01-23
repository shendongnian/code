        /// <summary>
        /// Exposes an interface for trusted callers to request that this
        /// instance of the application perform an action.
        /// </summary>
        public class AdministrationRequestHandler : IHttpHandler
        {
            /// <summary>
            /// Processes an incoming request and performs an action specified via the "action"
            /// parameter passed on the query string.  Only local callers will be allowed, and
            /// only callers who pass a shared password via the "sharedPassword" query string
            /// parameter.
            /// </summary>
            /// <param name="context"></param>
            public void ProcessRequest( HttpContext context )
            {
                //
                // get the action from the query string, and check that
                // it actually contains a value.
                string action = context.Request.QueryString["action"].ToSafeString().ToUpper( CultureInfo.InvariantCulture );
    
                if( string.IsNullOrEmpty( action ) )
                {
                    //
                    // Dump out an error message and return--we can't do anything
                    // without an action and this request may have malicious
                    // origins.
                    context.Response.Write( "Missing action." );
                    return;
                }
    
                //
                // Now validate the shared password that all web applications in this
                // solution should be using.  This password will NEVER be placed on a user's
                // query string or ever passed over a public network.
                string sharedPassword = context.Request.QueryString["sharedPassword"].ToSafeString();
    
                if( string.IsNullOrEmpty( sharedPassword ) )
                {
                    context.Response.Write( "Missing shared password." );
                    return;
                }
    
                //
                // check that the shared password is actually valid
                if( sharedPassword != AppSettings.SharedPassword )
                {
                    context.Response.Write( "Invalid shared password." );
                    return;
                }
    
                //
                // perform the specified action
                if( action == "CLEAR_CACHE" )
                {
                    AppContext.ClearUserCaches();
                }
            }
    
            /// <summary>
            /// Specifies whether or not the instance is reusable.
            /// </summary>
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
