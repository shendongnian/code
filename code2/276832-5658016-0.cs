    public class Test
    {
       public string FirstName { get; set; }
     
       public string LastName { get; set; }
    
       public override string ToString()
       {
          // Do your formatting here
          return LastName + ", " + FirstName;
       }
    }
