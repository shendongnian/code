    public class Person
    {
         public int PersonId { get; set; }
         public string Forename { get; set; }
         public string Surname { get; set; } 
         
         // add a collection-reference to roles
         public virtual ICollection<Role> Roles { get; set; } 
         
         // add a collection-reference to visites
         public virtual ICollection<Visit> Visits { get; set; }  
    }
***
    public class Visit
    {
         public int VisitId { get; set; }
         public string Name {get; set;}
         public string VisitStatus { get; set; }
    
         public int PersonId { get; set; }
         public virtual Person People { get; set; }  
         //There is a one to many relationship to person
    }
