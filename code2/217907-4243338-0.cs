        void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;
            
            string host = FirstRequestInitialisation.Initialise(context);
        }
        class FirstRequestInitialisation
        {
            private static string host = null;
            private static Object s_lock = new Object();
            // Initialise only on the first request
            public static string Initialise(HttpContext context)
            {
                if (string.IsNullOrEmpty(host))
                {
                    lock (s_lock)
                    {
                        if (string.IsNullOrEmpty(host))
                        {
                            Uri uri = HttpContext.Current.Request.Url;
                            host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                        }
                    }
                }
                return host;
            }
        }
