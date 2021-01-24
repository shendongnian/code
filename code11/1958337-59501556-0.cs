    public class User
    {
        public string LastName {get; private set;}
    
        public void SetLastName(string lastName)
        {
           if(string.IsNullOrEmpty(lastName))
             throw new Exception("LastName must be filled.");
    
           LastName = lastName;
        }
    }
