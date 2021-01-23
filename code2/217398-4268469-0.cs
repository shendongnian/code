    public interface IAddress
    {
        string Steet { get; }
        string ZipCode { get; }
        string City { get; }
    }
    
    public interface IMailingAddress : IAddress
    {
        string FullAddress { get; }
    }
    
    public static class AddressFactory
    {
        private class Address : IAddress
        {
            public string Steet { get; set; }
            public string ZipCode { get; set; }
            public string City { get; set; }
        }
    
        private class MailingAddress : Address, IMailingAddress
        {
            public string FullAddress
                { get { return string.Format("{0} {1} {2}", Steet, ZipCode, City); } }
        }
    
        static public IAddress MakeAddress(string street, string zip, string city)
            { return new Address() { Steet = street, ZipCode = zip, City = city }; }
    
        static public IMailingAddress MakeMailingAddress(IAddress address)
            { return new MailingAddress() { Steet = address.Steet, ZipCode = address.ZipCode, City = address.City }; }
    }
    
    
    public class Company
    {
        private IAddress _address;
    
        private Company(IAddress address) { _address = address; }
    
        static public Company Make(IAddress address)
            { return new Company(address); }
    
        public IAddress Address
            { get { return _address; } }
    
        public IMailingAddress MailingAddress
            { get{return AddressFactory.MakeMailingAddress(_address);} }
    
    }
