    namespace PageData.Extensions
    {
        public static partial class PageDataExtensions
        {
            public static string UserName(this PageData page)
            {
                return page["UserName"] as string;
            }
        }
    }
