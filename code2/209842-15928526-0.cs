    // HttpContext.Current.User.Identity.IsAuthenticated == true;
    FormsAuthentication.SignOut();
    HttpContext.Current.User =
        new GenericPrincipal(new GenericIdentity(string.Empty), null);
    // now HttpContext.Current.User.Identity.IsAuthenticated == false
    // and Page.User.Identity.IsAuthenticated == false
