    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Web;
    using System.Web.SessionState;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace AspNetLib.Controls
    {
    /*
     * This component should be placed in the <head> html tag and not in the body or form.
     */
    [DefaultProperty("Noscript")]
    [ToolboxData("<{0}:NoJavascript runat=server />")]
    public class NoJavascript : WebControl
    {
        HttpRequest Request = HttpContext.Current.Request;
        HttpSessionState Session = HttpContext.Current.Session;
        HttpResponse Response = HttpContext.Current.Response;
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue(false)]
        [Localizable(true)]
        public bool Noscript
        {
            get
            {
                bool noscript;
                // check if we've detected no script before
                try
                {
                    noscript = Convert.ToBoolean(Session["js:noscript"] ?? false);
                    if (noscript) return true;
                }
                catch { } // if session disabled, catch its error
                HttpCookie Cookie = Request.Cookies["JavascriptDetectionComponent"];
                if (null != Cookie)
                {
                    noscript = !string.IsNullOrEmpty(Cookie["js:noscript"]);
                    if (noscript) return true;
                }
                noscript = Convert.ToBoolean(ViewState["js:noscript"] ?? false);
                if (noscript) return true;
                // if we've returned from meta evaluate noscript query setting
                noscript = !string.IsNullOrEmpty(Request["noscript"]);
                if (noscript)
                {
                    SetNoScript();
                    return true;
                }
                return false;
            }
        }
        [Bindable(true)]
        [Category("Misc")]
        [DefaultValue("")]
        [Localizable(true)]
        public string CookieDomain
        {
            get { return Convert.ToString(ViewState["CookieDomain"] ?? string.Empty); }
            set { ViewState["CookieDomain"] = value; }
        }
        private void SetNoScript()
        {
            try { Session["js:noscript"] = true; }
            catch { }// if session disabled, catch its error
            ViewState["js:noscript"] = true;
            HttpCookie Cookie = new HttpCookie("JavascriptDetectionComponent");
            if (!string.IsNullOrEmpty(CookieDomain))
                Cookie.Domain = CookieDomain;
            Cookie["js:noscript"] = "true";
            Response.Cookies.Add(Cookie);
        }
        protected override void RenderContents(HtmlTextWriter output)
        {
            if (!Noscript)
            {
                string url = Request.Url.ToString();
                string adv = "?";
                if (url.Contains('?'))
                    adv = "&";
                string meta = string.Format("<META HTTP-EQUIV=\"Refresh\" CONTENT=\"0; URL={0}{1}noscript=true\">",
                    url, adv);
                output.WriteLine("<noscript>");
                output.WriteLine("  " + meta);
                output.WriteLine("</noscript>");
            }
        }
    }
    }
