    public void OnAuthorization(AuthorizationContext filterContext)
        {
            IUser user = _currentUserProvider.CurrentUser;
            if (user != null)
            {
                // you can perform perform additional user-authorization here...        
                if(_authorizationService.IsAuthorized(user))
                {
                   //user is authorized
                   return;
                }
                else
                {     
                   HandleUnAuthorizedRequest(filterContext);
                   return;
                }
            }
            //user is not authenticated (not logged in)
            HandleUnAuthenticatedRequest(filterContext);
        }
