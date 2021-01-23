      class Program
      {
        static void Main(string[] args)
        {
          Customer c = new Customer() { Name = "Mike" };
          SomeMethod(c);
          Console.WriteLine(c.Name);
        }
    
        static void SomeMethod(Customer customer)
        {
          customer.Name = "John";
        }
      }
    
      class Customer
      {
        public string Name { get; set; }
      }
