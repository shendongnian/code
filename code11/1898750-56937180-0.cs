    public static class HtmlHelperExtensions
    {
        public static IIdentity GetUserId(this HtmlHelper helper)
        {
            var userIdentity = helper.ViewContext.HttpContext.User.Identity;
            return userIdentity;
        }
    }
