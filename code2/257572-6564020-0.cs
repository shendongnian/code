    using Facebook.Web;
    using Facebook;
    using System.Dynamic;
    var auth = new CanvasAuthorizer { Permissions = new[] { "user_about_me"} };
    
    if (auth.Authorize())
    {
    }
