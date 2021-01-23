    using System;
    using System.Collections.Specialized;
    using System.Web; // For this you need to reference System.Web assembly from the GAC
    
    public static class UriExtensions
    {
        public static Uri SetQueryVal(this Uri uri, string name, object value)
        {
            NameValueCollection nvc = HttpUtility.ParseQueryString(uri.Query);
            nvc[name] = (value ?? "").ToString();
            return new UriBuilder(uri) {Query = nvc.ToString()}.Uri;
        }
    }
