    namespace System.Web.Mvc.Html
    {
        public static class MyExtensions
        {
            public static MvcHtmlString DisplayObject(this HtmlHelper htmlHelper, string propertyName, object anonymousModel)
            {
                string result = anonymousModel.GetType().GetProperty(propertyName).GetValue(anonymousModel).ToString();
                return new MvcHtmlString(result);
            }
        }
    }
