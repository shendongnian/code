    @using System.Web.Mvc.Html
    @using System.Web.Mvc
    @helper HelloWorld(WebViewPage page)
    {
        @page.Html.Label("HelloWorld")
    }
