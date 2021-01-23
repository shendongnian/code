    if (HttpContext.Current.User.Identity.IsAuthenticated) {
       Name = HttpContext.Current.User.Identity.Name;
    } 
    else 
    { 
       Name = "Anonymous"
    }
