    public interface IContactFactory
    {
        IContact CreateContact(string name);
    }
    
    class AddressBook
    {
        private IContactFactory _factory;
        private List<IContact> _contacts;
    
        public AddressBook(IContactFactory factory){ _factory = factory; }        
    
        public AddContact(string name)
        {
            _contacts.Add(_factory.CreateContact(name));
        }
    }
