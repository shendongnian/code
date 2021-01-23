    using System;
    namespace YourProject.Extensions
    {
        public static class UriExtensions
        {
            public static string Path(this Uri uri)
            {
                if (uri == null)
                {
                    throw new ArgumentNullException("uri");
                }
                return uri.GetLeftPart(UriPartial.Path);
            }
        }
    }
