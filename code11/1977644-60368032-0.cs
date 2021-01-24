    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
    }
    
    public class Person : IPerson
    {
        string IPerson.Name { get; set; } 
        int IPerson.Age { get; set; }
    }
