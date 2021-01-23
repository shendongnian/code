    [AttributeUsage( AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true )]
      public class CustomValidateAntiForgeryToken : FilterAttribute, IAuthorizationFilter {
        public void OnAuthorization( AuthorizationContext filterContext ) {
          if ( filterContext == null ) {
            throw new ArgumentNullException( "filterContext" );
          }
        
          try {
            AntiForgery.Validate();
          }
          catch {
            // Here do whatever is you wish 
            // you could just re throw the error or what ever.
            // In this case I have redirected to a Signout
            filterContext.Result = new RedirectToRouteResult( 
              new RouteValueDictionary( 
                new {
                  action     = "Sign_Out",
                  controller = "SOME_CONTROLLER",
                  area       = ""
                } 
              )
            );
        
          }
      
        }
      }
