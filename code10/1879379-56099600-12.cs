    public class DefaultDependencyModule : Module
    {
        public string BaseUrl { get; set; }
        public string AccountId { get; set; }
        public string ApplicationKey { get; set; }
        protected override void Load(ContainerBuilder builder)
        {
            //dear inventory api service
            builder.Register(r =>
            {
                var logger = r.Resolve<ILogger<DearInventoryApiService>>();
                return new DearInventoryApiService(logger, BaseUrl, AccountId, ApplicationKey);
            }).As<IDearInventoryService>();   
        }
    }
