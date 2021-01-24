c#
        public void Configuration(IAppBuilder app)
        {
            var container = new ServiceContainer();
            container.RegisterControllers(typeof(Web.Controllers.DashboardController).Assembly);
            ConfigureHangfire(container,app);
            
            ConfigureServices(container);
            container.EnableMvc();
        }
I hope that helps someone!
