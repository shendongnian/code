    public class AddressDisplay
    {
        private Retailer _retailer;
        private BusinessAddress _address;
    
        public AddressDisplay(Retailer retailer, BusinessAddress address)
        {
            _retailer = retailer;
            _address = address;
        }
        public string ApplicationNumber
        {
            get { return _retailer.ApplicationNumber; }
        }
        public string Status
        {
            get { return _retailer.Status; }
        } 
        public string Street
        {
            get { return _address.Street1; }
            set { _address.Street1 = value; }
        }
        public string City
        {
            get { return _address.City; }
            set { _address.City = value; }
        }
    }
