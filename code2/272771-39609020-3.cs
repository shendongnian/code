    public class Person
    {
         public int Id { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public string MiddleName { get; set; }
         public int Age { get; set; }
         public int DocumentId {get; set;}
    
         public virtual ICollection<Phone> Phones { get; set; }
         public virtual Document Document { get; set; }
         public virtual PersonSpouse PersonSpouse { get; set; }
    }
