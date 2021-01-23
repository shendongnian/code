    @using System.Web.Mvc.Html 
    ...
    @functions {
        protected static new System.Web.Mvc.HtmlHelper Html
        {
            get
            {
                return ((System.Web.Mvc.WebViewPage)WebPageContext.Current.Page).Html;    
            }
       }
    }
