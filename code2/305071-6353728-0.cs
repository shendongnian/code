    public class AddressCollection : Collection<IAddress>, IAddressCollection
    {
        public AddressCollection() : base(new List<IAddress>())
        {
        }
    }
