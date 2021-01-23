    public class BaseController : Controller {
        private readonly IProvider AddressProvider = null;
        private readonly IProvider EmailProvider = null;
        private readonly IProvider PhoneProvider = null;
        [Inject] // Using Ninject for DI
        public BaseController(
            AddressProvider AddressProvider,
            EmailProvider EmailProvider,
            PhoneProvider PhoneProvider) {
            this.AddressProvider = AddressProvider;
            this.EmailProvider = EmailProvider;
            this.PhoneProvider = PhoneProvider;
        }
    }
