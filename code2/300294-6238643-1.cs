    public class Person {
       public string Name { get; set; }
    }
    public class Customer : Person {
       
    }
    public class Staff : Person {
    }
    
    public class HumanResources : Staff {
    }
    
    public class Db {
      public List<Customer> Customers { get; set; }
      public List<Staff> Staff { get; set; }
    }
    
    public static void Main(){ 
      var db = new Db {
         Customers = new List<Customer> { },
         Staff = new List<Staff> { }
      };
      
      Db.Customers.Add(new Customer { Name = "Primary Customer" } );
      Db.Staff.Add(new Staff { Name = "Employee Prime" } );
      Db.Staff.Add(new HumanResources { Name = "Human Resource Manager" });
    }
