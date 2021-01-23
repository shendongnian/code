        void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            var host = FirstRequestInitialisation.Initialise(app.Context);
        }
        static class FirstRequestInitialisation
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
                            var uri = context.Request.Url;
                            host = uri.GetLeftPart(UriPartial.Authority);
                        }
                    }
                }
                return host;
            }
        }
