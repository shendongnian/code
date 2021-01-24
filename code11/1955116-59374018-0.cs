    using Microsoft.AspNetCore.Mvc.RazorPages;
    namespace WebApplication1.Extensions
    {
        public static class PageModelExtension
        {
            public static string RemoteIpAddress(this PageModel pageModel)
            {
                return pageModel.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
        }
    }
