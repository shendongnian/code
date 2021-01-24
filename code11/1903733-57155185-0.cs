    namespace Microsoft.AspNetCore.Mvc.Rendering
    {
        public static class HelperExtensions
        {
            public static IHtmlContent JsString<TModel>(this IHtmlHelper<TModel> helper, string value)
            {
                return helper.Raw(System.Web.HttpUtility.JavaScriptStringEncode(value));
            }
        }
    }
