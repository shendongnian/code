        public static string AppendQuerystring( string keyvalue)
        {
            return AppendQuerystring(System.Web.HttpContext.Current.Request.RawUrl, keyvalue);
        }
        public static string AppendQuerystring(string url, string keyvalue)
        {
            string dummyHost = "http://www.test.com:80/";
            if (!url.ToLower().StartsWith("http"))
            {
                url = String.Concat(dummyHost, url);
            }
            UriBuilder builder = new UriBuilder(url);
            string query = builder.Query;
            var qs = HttpUtility.ParseQueryString(query);
            string[] pts = keyvalue.Split('&');
            foreach (string p in pts)
            {
                string[] pts2 = p.Split('=');
                qs.Set(pts2[0], pts2[1]);
            }
            StringBuilder sb = new StringBuilder();
            foreach (string key in qs.Keys)
            {
                sb.Append(String.Format("{0}={1}&", key, qs[key]));
            }
            builder.Query = sb.ToString().TrimEnd('&');
            string ret = builder.ToString().Replace(dummyHost,String.Empty);
            return ret;
        }
