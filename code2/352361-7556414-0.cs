    [Export(typeof(IMyService))]
    public class MyService: IMyService
    {
        private readonly IContext context;
        
        public MyService(
            [Import(typeof(IContext),      
                RequiredCreationPolicy=CreationPolicy.NonShared)]
            IContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            this.context = context;
        }
    
        public void DoTheJob()
        {
            // Logic goes here
        }
    }
