        public void RegisterTimeoutWarning(System.Web.UI.Page Page)
        {
            var timeout = HttpContext.Current.Session.Timeout * 60 * 1000;
            Page.ClientScript.RegisterStartupScript(Page.GetType(), 
                    "timeoutWarning", 
                    string.Format("setTimeout(function () {{ alert('Session about to expire'); }}, {0});", timeout), true);
        }
