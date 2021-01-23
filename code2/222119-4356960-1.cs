    public class AdministrationController : BaseController {
        private readonly CustomerProvider CustomerProvider = null;
        private readonly EmployeeProvider EmployeeProvider = null;
        [Inject]
        public AdministrationController(
            CustomerProvider CustomerProvider,
            EmployeeProvider EmployeeProvider,
            AddressProvider AddressProvider,
            EmailProvider EmailProvider,
            PhoneProvider PhoneProvider) : base(AddressProvider, EmailProvider, PhoneProvider) {
            this.CustomerProvider = CustomerProvider;
            this.EmployeeProvider = EmployeeProvider;
        }
    }
