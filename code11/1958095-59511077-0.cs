        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Context.Items.Add("serviceScope", Startup.Provider.CreateScope());
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var serviceScope = Context.Items["serviceScope"] as IServiceScope;
            serviceScope?.Dispose();
        }
