    public static class MyHtmlHelpers {
      public static MvcHtmlString ChangeLanguageLink(this HtmlHelper html, string label, string newLang) {
        html.ViewContext.RouteData.Values["lang"] = newLang;
        return html.ActionLink(label, html.ViewContext.RouteData.Values["action"], ViewContext.RouteData.Values);
      }
    }
