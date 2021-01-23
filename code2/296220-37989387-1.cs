    class Contact
    {
        public int Person { get; set; }
        private OwnedList<Address> _Addresses;
        public OwnedList<Address> Addresses
        {
            get
            {
                if (_Addresses == null)
                {
                    _Addresses = new OwnedList<Address>(this);
                }
                return _Addresses;
            }
            set
            {
                _Addresses = value;
                _Addresses.Owner = this;
            }
        }       
    }
