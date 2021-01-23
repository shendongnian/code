    @if ( Request.IsAuthenticated)
    {
            @* when we are authenticated, don't cache any more! *@
    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
    HttpContext.Current.Response.Cache.SetNoStore();
    HttpContext.Current.Response.Cache.SetNoServerCaching();
            @*@Html.Raw(DateTime.Now.ToString())*@
    @Html.ActionLink("Welcome " + ( String.IsNullOrEmpty(((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirstValue("UserName")) ? User.Identity.Name : ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirstValue("UserName")), "Index", "Manage", routeValues: new { Area = "Store" }, htmlAttributes: new { title = "Manage"})
    }
    else
    {
    }
