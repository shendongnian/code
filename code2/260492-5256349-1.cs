     Dictionary<string, object> parms = new Dictionary<string, object>();
                    parms.Add( "method", "pages.isFan" );
                    parms.Add( "page_id", YourAppId );
                    parms.Add( "uid", UsersFbId );
                    var isFan = fb.Api( parms );
                    if( (bool)isFan )
                    {
                      //this user is a fan
                    }
