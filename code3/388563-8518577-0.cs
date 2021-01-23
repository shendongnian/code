    public static class MyHtmlExtensions {
        public static MvcHtmlString MyActionLink(this HtmlHelper html, string action, string controller, string ajaxUpdateId, string spanText) {
             var url = UrlHelper.GenerateContentUrl("~/" + controller + "/" + action);
             var result = new StringBuilder();
             result.Append("<a href=\"");
             result.Append(HttpUtility.HtmlAttributeEncode(url));
             result.Append("\" data-ajax-update=\"");
             result.Append(HttpUtility.HtmlAttributeEncode("#" + ajaxUpdateId));
             // ... and so on
             return new MvcHtmlString(result.ToString());
        }
    }
