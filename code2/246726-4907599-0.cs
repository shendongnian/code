    public static class UrlHelperExtensions
    {
        public static string UrlToTheControllerAction(this UrlHelper helper)
        {
            return helper.Action("TheAction", "TheController");
        }
    }
