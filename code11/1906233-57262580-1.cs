    public class DemoController : Controller
    {
        private IHubContext<ITypedClient> context;
    
        public DemoController(IHubContext<ITypedClient> context)
        {
            this.context = context;
        }
    }
