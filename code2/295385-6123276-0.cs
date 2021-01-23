    var ident = (System.Security.Principal.WindowsIdentity)HttpContext.Current.User.Identity;
    If(!ident.IsAnonymous && ident.IsAuthenticated)
    {
      var loginUsername = ident.Name;
    }
