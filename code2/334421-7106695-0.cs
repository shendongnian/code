    public class Base {
    
      // field initialiser:
      private string _firstName = "Arthur";
    
      public string FirstName { get { return _firstName;}}
      public string LastName { get; private set; }
      // initialiser in base constructor:    
      public Base() {
        LastName = "Dent";
      }
    
    }
    
    public class Derived : Base {
    
      public string FirstNameCopy { get; private set; }
      public string LastNameCopy { get; private set; }
    
      public Derived() {
        // get values from base class:
        FirstNameCopy = FirstName;
        LastNameCopy = LastName;
      }
    
    }
