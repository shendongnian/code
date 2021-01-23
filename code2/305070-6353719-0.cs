    public class AddressCollection : IAddressCollection
    {
        private List<IAddress> _data = new List<IAddress>();
        public void Add(IAddress applicationAddress)
        {
            if (!this.Any(x => x.AddressType != applicationAddress.AddressType))
            {
                _data.Add(applicationAddress);
            }
        }
    
        // Plus all other members of IAddressCollection
    }
