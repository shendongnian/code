    public class LeadOrganization
    {
        private ILazyLoader _lazyLoader { get; set; }
        private IEnumerable<LeadOrganizationAddress> _addresses;
        public LeadOrganization(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        public IEnumerable<LeadOrganizationAddress> Addresses
        {
            get => _addresses;
            set => _addresses = value;
        }
        public IEnumerable<LeadOrganizationAddress> AddressesLazy
        {
            get
            {
                _lazyLoader?.Load(this, ref _addresses);
            }
            set => this._addresses = value;
        }
    }
