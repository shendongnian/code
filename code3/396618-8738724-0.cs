        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(context_PreRequestHandlerExecute);
        }
        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            HttpContext context = app.Context;
            HttpResponse response = context.Response;
            if (IsLoginPage(context))
            {
                // ...
            }
            else if (IsLogoutPage(context))
            { 
                // ...
            }
        }
