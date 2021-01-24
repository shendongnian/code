    public class Gateway1 : IGateway
    {
        private readonly IPaymentTransactionRepository _paymentTransactionRepository;
        public Gateway1(IServiceProvider serviceProvider)
        {
            _paymentTransactionRepository = (IPaymentTransactionRepository)serviceProvider.GetService(typeof(IPaymentTransactionRepository));
        }
        public void Test()
        {
            //code
        }
    }
    public class Gateway2 : IGateway
    {
        private readonly IPaymentTransactionRepository _paymentTransactionRepository;
        private readonly IPaymentGatewayRepository _paymentGatewayRepository;
        public Gateway2(IServiceProvider serviceProvider)
        {
            _paymentTransactionRepository = (IPaymentTransactionRepository)serviceProvider.GetService(typeof(IPaymentTransactionRepository));
            _paymentGatewayRepository = (IPaymentGatewayRepository)serviceProvider.GetService(typeof(IPaymentGatewayRepository));
        }
        public void Test()
        {
            //code
        }
    }
