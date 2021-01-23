        protected void Application_Error( object sender , EventArgs e )
        {
            // only do something special if the request is not from the local machine.
            if ( !Request.IsLocal )
            {
                Exception     exception     = Server.GetLastError() ;
                HttpException httpException = exception as HttpException ;
                RouteData     routeData     = new RouteData() ;
                routeData.Values.Add( "controller" , "Error" ) ;
                if ( httpException != null )
                {
                    int httpStatusCode = httpException.GetHttpCode() ;
                    switch ( httpStatusCode )
                    {
                    case 404 : routeData.Values.Add( "action" , "Http404FileNotFound"        ) ; break ;
                    default  : routeData.Values.Add( "action" , "HttpError"                  ) ; break ;
                    }
                    routeData.Values.Add( "exception" , httpException ) ;
                }
                else
                {
                    routeData.Values.Add( "action" , "Http500InternalServerError" ) ;
                    routeData.Values.Add( "exception" , exception ) ;
                }
                Response.Clear() ;
                Server.ClearError() ;
                HttpContextBase contextWrapper  = new HttpContextWrapper( Context ) ;
                RequestContext  newContext      = new RequestContext( contextWrapper , routeData ) ;
                IController     errorController = new ErrorController() ;
                errorController.Execute( newContext ) ;
            }
            return ;
        }
