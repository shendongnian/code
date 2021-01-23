    public static class CustomHelpers
        {
            public static MvcHtmlString DocType(this HtmlHelper helper)
            {
                var docType = @"<!DOCTYPE ...>";
                return MvcHtmlString.Create(docType);
            }
        }
