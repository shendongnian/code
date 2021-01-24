        public static ISession CurrentSession
        {
            get { return (ISession) HttpContext.Current.Items[Sessionkey]; }
            private set { HttpContext.Current.Items[Sessionkey] = value; }
        }
        protected void Application_BeginRequest() { CurrentSession = SessionFactory.OpenSession(); }
        protected void Application_EndRequest()
        {
            if (CurrentSession != null)
                CurrentSession.Dispose();
        }
