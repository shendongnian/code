    public class PaymentFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public PaymentFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IGateway ExecuteCreation(PaymentGatewayEnum bank)
        {
            var services = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IGateway).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .FirstOrDefault(x => string.Equals(x.Name, bank.ToString(), StringComparison.CurrentCultureIgnoreCase));
            return Activator.CreateInstance(services, _serviceProvider) as IGateway;
        }
    }
