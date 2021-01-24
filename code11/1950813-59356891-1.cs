    public class Global : System.Web.HttpApplication
    {        
        public override void Init()
        {
            HttpRuntime.WebObjectActivator = new SimpleActivator();
            base.Init();
        }
    }
