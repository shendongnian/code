    public class BillPayingService
    {
        private readonly IBillingGateway _billingGateway;
        public BillPayingService(
                IBillingGateway billingGateway
            )
        {
            _billingGateway = billingGateway;
        }
        public void PayBills()
        {
           // ....
        }
    }
