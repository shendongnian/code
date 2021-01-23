        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.PathAndQuery;
            string application = HttpContext.Current.Request.ApplicationPath;
            if (!url.StartsWith(application))
            {
                HttpContext.Current.Response.Redirect(application + url.Substring(application.Length));
                Response.End();
                return;
            }
        }
