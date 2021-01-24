    public class AddressCollection : System.Collections.ObjectModel.Collection<Address>
    {
        public AddressCollection(IList<Address> addresses)
            : base(addresses)
        {
        }
        public AddressCollection()
        {
        }
    }
