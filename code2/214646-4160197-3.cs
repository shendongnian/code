      class Program
      {
        static void Main(string[] args)
        {
          Customer c = new Customer() { Name = "Mike" };
          SomeMethod(ref c);
          Console.WriteLine(c.Name);
        }
    
        static void SomeMethod(ref Customer customer)
        {
          customer = new Customer();
          customer.Name = "John";
        }
      }
    
      class Customer
      {
        public string Name { get; set; }
      }
