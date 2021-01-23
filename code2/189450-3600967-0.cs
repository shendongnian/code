    public static class HelperClass
    {
        public static string GetUsernameFromSession()
        {
            return HttpContext.Current.Session["Username"].ToString();
        }
    }
