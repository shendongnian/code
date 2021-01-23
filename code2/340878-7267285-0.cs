       [WebMethod]
       public void HelloWorld()
       {
          if (this.DoesUserHaveRights(HttpContext.Current.User))
          {
              // do the work here
          }
          else
             throw new AuthenticationException();
       }
