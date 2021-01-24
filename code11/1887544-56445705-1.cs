    namespace Microsoft.AspNetCore.Mvc.Razor
    {
        
        public class RazorViewEngine : IRazorViewEngine, IViewEngine
        {
            public static readonly string ViewExtension;
            protected IMemoryCache ViewLookupCache { get; }
            public static string GetNormalizedRouteValue(ActionContext context, string key);
            public RazorPageResult FindPage(ActionContext context, string pageName);
            public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage);
            public string GetAbsolutePath(string executingFilePath, string pagePath);
            public RazorPageResult GetPage(string executingFilePath, string pagePath);
            public ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage);
        }
    }
