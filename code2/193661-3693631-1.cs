    if (Session["RedirectFlag"] != null && (bool)Session["RedirectFlag"])
    {
        // clear your placeholder
        Session.Remove("RedirectFlag"); // clear the flag
    }
..
    public static class HttpResponseExtension
    {
        public static void RedirectWithFlag(this HttpResponse response, string url)
        {
            response.RedirectWithFlag(url, true);   
        }
        public static void RedirectWithFlag(this HttpResponse response, string url, bool endResponse)
        {
            System.Web.HttpContext.Current.Session["RedirectFlag"] = true;
            response.Redirect(url, endResponse);
        }
    }
