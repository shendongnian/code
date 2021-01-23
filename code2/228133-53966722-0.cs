    class Program
    {
       static void Main(string[] args)
       {
          List<string> CustomerList_One = new List<string> 
          {
             "James",
             "Scott",
             "Mark",
             "John",
             "Sara",
             "Mary",
             "William",
             "Broad",
             "Ben",
             "Rich",
             "Hack",
             "Bob"
          };
    
          List<string> CustomerList_Two = new List<string> 
          {
             "Perter",
             "Parker",
             "Bond",
             "been",
             "Bilbo",
             "Cooper"
          };
          
          // Adding all contents of CustomerList_Two to CustomerList_One.
          CustomerList_One.AddRange(CustomerList_Two);
    
          // Creating another Listlist and assigning all Contents of CustomerList_One.
          List<string> AllCustomers = new List<string>();
    
          foreach (var item in CustomerList_One)
          {
             AllCustomers.Add(item);
          }
    
          // Removing CustomerList_One & CustomerList_Two.
          CustomerList_One = null;
          
          CustomerList_Two = null;
          // CustomerList_One & CustomerList_Two -- (Garbage Collected)
          GC.Collect();
          Console.WriteLine("Total No. of Customers : " +  AllCustomers.Count());
          Console.WriteLine("-------------------------------------------------");
          foreach (var customer in AllCustomers)
          {
             Console.WriteLine("Customer : " + customer);
          }
          Console.WriteLine("-------------------------------------------------");
    
       }
    }
