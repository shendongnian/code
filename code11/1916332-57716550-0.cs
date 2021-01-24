        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var ip = HttpContext.Current.Request.UserHostAddress;
            //TODO: handle correct list
            List<string> validIps = new List<string> { "::1" };
            if (!validIps.Contains(ip))
            {
                HttpContext.Current.Response.StatusCode = 403;
                HttpContext.Current.Response.StatusDescription = "Forbidden";
                HttpContext.Current.Response.End();
            }
        }
