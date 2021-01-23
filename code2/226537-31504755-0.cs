	// These are important for `Html.RouteLink` and such.
	@using System.Web.Mvc;
	@using System.Web.Mvc.Routing;
	@using System.Web.Mvc.Html;
	@using System.Web.Mvc.Razor;
	@helper SomeHelper()
	{
		// Get page and pull helper references from it.
		var wvp = PageContext.Page as System.Web.Mvc.WebViewPage;
		var Url = wvp.Url; // UrlHelper access
		var Html = wvp.Html; // HtmlHelper access
		var ViewBag = wvp.ViewBag;
		// Helper code comes here...
	}
