    public Person  {
      private List<Address> _addresses;
      public ReadonlyCollection<Address> Addresses {
        get { return _addresses.AsReadOnly(); }
      }
      public void AddAddress(Address address) {
        _addresses.Add(address);
      }
    }
