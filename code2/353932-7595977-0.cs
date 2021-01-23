    public class MyService: IMyService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IBillingRepository _billingRepository;
        public MyService(IAccountRepository accountRepository, IInvoiceRepository invoiceRepository, IBillingRepository billingRepository)
        {
            _accountRepository = accountRepository;
            _invoiceRepository = invoiceRepository;
            _billingRepository = billingRepository;
        }
       
        public void UpgradeAccountPackage(PackageType packageType, int accountId)
        {
            ...
        }
        
    }
