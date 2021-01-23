        public class MyHttpApplication:HttpApplication
        {
            public event Action ApplicationEnd;
            protected void Application_End()
            {
                if (ApplicationEnd != null)
                   ApplicationEnd();
            } 
        }
