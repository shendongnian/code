    var userNameClaim = new Claim(ClaimTypes.Name, appID);
    var identity = new ClaimsIdentity(new[] { userNameClaim }, "Admin");
    var principal = new ClaimsPrincipal(identity);
    Thread.CurrentPrincipal = principal;
    if (System.Web.HttpContext.Current != null)
      {
        System.Web.HttpContext.Current.User = principal;
      }
