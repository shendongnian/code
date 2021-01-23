    public class Person
    {
      public int ID { get; set; }
      public string Name { get; set; }
      public virtual ICollection<Address> Addresses { get; set; }
    }
    public class Address
    {
      public int ID { get; set; }
      public AddressLine { get; set; }
      public int StateID { get; set; }
      public ICollection<State> { get; set; }
    }
