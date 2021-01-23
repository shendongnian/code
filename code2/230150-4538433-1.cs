    public class SwfUploadSupportModule : IHttpModule
    {
        public void Dispose()
        {
            // clean-up code here.
        }
        public void Init(HttpApplication application)
        {
            application.BeginRequest += new EventHandler(OnBeginRequest);
        }
        private void OnBeginRequest(object sender, EventArgs e)
        {
            var httpApplication = (HttpApplication)sender;
            /* we guess at this point session is not already retrieved by application so we recreate cookie with the session id... */
            try
            {
                string session_param_name = "ASPSESSID";
                string session_cookie_name = "ASP.NET_SessionId";
                if (httpApplication.Request.Form[session_param_name] != null)
                {
                    UpdateCookie(httpApplication, session_cookie_name, httpApplication.Request.Form[session_param_name]);
                }
                else if (httpApplication.Request.QueryString[session_param_name] != null)
                {
                    UpdateCookie(httpApplication, session_cookie_name, httpApplication.Request.QueryString[session_param_name]);
                }
            }
            catch
            {
            }
            try
            {
                string auth_param_name = "AUTHID";
                string auth_cookie_name = FormsAuthentication.FormsCookieName;
                if (httpApplication.Request.Form[auth_param_name] != null)
                {
                    UpdateCookie(httpApplication, auth_cookie_name, httpApplication.Request.Form[auth_param_name]);
                }
                else if (httpApplication.Request.QueryString[auth_param_name] != null)
                {
                    UpdateCookie(httpApplication, auth_cookie_name, httpApplication.Request.QueryString[auth_param_name]);
                }
            }
            catch
            {
            }            
        }
        private void UpdateCookie(HttpApplication application, string cookie_name, string cookie_value)
        {
            var httpApplication = (HttpApplication)application;
            HttpCookie cookie = httpApplication.Request.Cookies.Get(cookie_name);
            if (null == cookie)
            {
                cookie = new HttpCookie(cookie_name);
            }
            cookie.Value = cookie_value;
            httpApplication.Request.Cookies.Set(cookie);
        }
    }
