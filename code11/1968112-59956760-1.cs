    public class Person
    {
       public Person()
       {
    		this.Hobbies = new List<string>(); // Since you are instantiating here, you don't need to instantiate again in Survey or wherever/whenever you instantiate Person object in your application.
       }
       public string FirstName {set;get:}
       public string LastName {set;get;}
       public string Country {set;get;
       public List<string> Hobbies; // Modify this to property public List<string> Hobbies {get; set;}
    
    }
