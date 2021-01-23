        if(HttpContext.Current.User.Identity.IsAuthenticated)
        {
            return HttpContext.Current.User.Identity.Name;
        }
        else
        {
            return null;
        }
