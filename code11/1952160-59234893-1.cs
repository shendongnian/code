    public class OrderScheduler
    {
        public readonly ScheduledTaskSettings _scheduledTaskSettings;
        public OrderScheduler(IOptions<ScheduledTaskSettings> scheduledTaskSettings)
        {
            _scheduledTaskSettings = scheduledTaskSettings.Value;
        }
        // using read-only properties instead
        private string CustomerApiUrl => _scheduledTaskSettngs.CustomersApiEndpointUrl;
        private string SubscriptionApiUrl => _scheduledTaskSettngs.SubscriptionsApiEndpointUrl;
        private string CatalogApiUrl => _scheduledTaskSettngs.ProductsApiEndpointUrl;
        private string SubscriberUrl => _scheduledTaskSettngs.SubscribersApiEndpointUrl;
        private string _connectionString => _scheduledTaskSettngs.ConnectionString;
        // …
        // instance members only, no “static”
    }
