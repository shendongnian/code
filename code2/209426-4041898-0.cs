    public class QueryStringState
    {
        private Dictionary<string, string> m_Params = new Dictionary<string, string>();
        private System.Web.UI.Page m_Page;
        // ctor
        public QueryStringState(System.Web.UI.Page _page, params string[] _persistArgs)
        {
            m_Page = _page;
            foreach (string key in _page.Request.QueryString.Keys)
            {
                if (_persistArgs.Contains(key))  // are we persisting this?
                    m_Params[key] = _page.Request.QueryString[key];
            };
        }   // eo ctor
        // Resolve Url
        public string ResolveUrl(string _url)
        {
            // Resolve the URL appropriately
            string resolved = m_Page.ResolveUrl(_url);
            
            // Add our arguments on to the Url.  This assumes that they have NOT been
            // put on the query string manually.
            Uri uri = new Uri(resolved);
            StringBuilder builder = new StringBuilder(uri.Query);
            if(uri.Query.Length > 0)
                builder.Append("&");
            int counter = 0;
            foreach(KeyValuePair<string, string> pair in m_Params)
            {
                builder.AppendFormat("{0}={1}", pair.Key, pair.Value);
                ++counter;
                if(counter < m_Params.Count)
                    builder.Append("&");
            };
            
            return(string.Concat(resolved, builder.ToString()));
        }
    };
