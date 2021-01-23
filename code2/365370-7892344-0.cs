    if ( HttpContext.Current.User != null )
    {
         if ( HttpContext.Current.User.Identity != null )
              {
              string username = HttpContext.Current.User.Identity.Name.ToString();
    
              bool yesno = HttpContext.Current.User.IsInRole("Group0Users");
    
              string role = GetRole.OfUser(username);
              }
    
    }
