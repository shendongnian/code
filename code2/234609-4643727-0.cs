    public class Person 
    {
       public int Id { get; set;}
       public string Name { get; set;} 
       public Person Mother { get; set;}
       public int? MotherId { get; set;}
       public Person Father { get; set;}
       public int? FatherId { get; set;}
    }
