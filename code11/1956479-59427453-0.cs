    public static class GridLayoutExtensions
    {
        public static MvcHtmlString GetGridHtml(this HtmlHelper html, IPublishedElement publishedElement, string propertyAlias)
        {
            if (propertyAlias == null)
            {
                return new MvcHtmlString("");
            }
    
            var model = publishedElement
                .GetProperty(propertyAlias)
                .GetValue();
    
            return html.Partial("Grid/bootstrap3", model);
        }
    }
