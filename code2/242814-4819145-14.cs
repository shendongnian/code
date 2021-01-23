    HttpContext context = HttpContext.Current; 
    if (context != null && context.User != null && context.User.Identity.IsAuthenticated)
    {     
      MDC.Set("user", HttpContext.Current.User.Identity.Name); 
    } 
