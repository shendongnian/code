    public static class MyHttpUtilities
    {
        public static System.Collections.Generic.Dictionary<string, string>
            ParseQueryString(this string queryString)
        {
            System.Collections.Generic.Dictionary<string, string> r = 
                new Dictionary<string, string>();
            // remove extra noise
            queryString = queryString.TrimStart('?').Replace("amp;", ""); 
            // split up and fill up Dictionary
            foreach (string s in queryString.Split('&'))
            {
                if (s.Contains('='))
                {
                    string[] par = s.Split('=');
                    r.Add(par[0], par[1]);
                }
            }
            return r;
        }
    }
