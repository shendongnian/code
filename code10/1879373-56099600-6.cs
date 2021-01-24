    public class DefaultDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //dear inventory api service
            builder.Register((c, p) =>
            {
                string baseUrl = p.Named<string>("baseUrl");
                string accountId = p.Named<string>("accountId");
                string baseUrl = p.Named<string>("baseUrl");
                var logger = r.Resolve<ILogger<DearInventoryApiService>>();
                return new DearInventoryApiService(logger, baseUrl, accountId, applicationKey);
            })
            .As<IDearInventoryService>();   
        }
    }
