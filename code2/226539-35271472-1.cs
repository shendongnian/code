    @using System.Web.Mvc;
    @using System.Web.Mvc.Html;
    @using System.Web.Mvc.Routing;
    @using System.Web.Mvc.Razor;
    @functions {
        private static WebViewPage page { get { return PageContext.Page as WebViewPage; } }
        private static System.Web.Mvc.HtmlHelper Html { get { return page.Html; } }
        private static UrlHelper Url { get { return page.Url; } }
        private static dynamic ViewBag { get { return page.ViewBag; } }
    }
