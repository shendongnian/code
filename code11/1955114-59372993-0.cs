    namespace MyDll.MyNamespace
    {
        public static class PageModelExtension
        {
            public static string RemoteIpAddress(this PageModel pageModel)
            {
                return pageModel.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
        }
    }
