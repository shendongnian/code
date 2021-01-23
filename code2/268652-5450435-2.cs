    public class Customer
    {
      public String FirstName { get; set; }
      public String LastName { get; set; }
          
      public Customer(String firstName, String lastName)
      {
         this.FirstName = firstName;
         this.LastName = lastName;
      }
        
      public static ObservableCollection<Customer> GetSampleCustomerList()
      {
        return new ObservableCollection<Customer>(new Customer[4] {
                new Customer("Charlie", "Zero"), 
                new Customer("Cathrine", "One"),
                new Customer("Candy", "Two"),
                new Customer("Cammy", "Three")
            });
      }
    }
    
    
    public class Person
    {
      public String FirstName { get; set; }
      public String LastName { get; set; }
      
      public Person(String firstName, String lastName)
      {
         this.FirstName = firstName;
         this.LastName = lastName;
      }
       
      public static ObservableCollection<Person> GetSamplePersonList()
      {
        return new ObservableCollection<Person>(new Person[4] {
                new Person("Bob", "Smith"), 
                new Person("Barry", "Jones"),
                new Person("Belinda", "Red"),
                new Person("Benny", "Hope")
            });
      }
    }
