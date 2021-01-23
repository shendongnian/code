    public class Person
    {
       //others can only get Person instances from your PersonManager
       internal Person() { }   
       
       public string FristName { get; set; }
       public string LastName { get; set; }
       
       // and some other properties/methods which are really related to a Person
    }
