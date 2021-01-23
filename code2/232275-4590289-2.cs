    interface IPerson
    {
     string Name {get; set;}
     string Salt {get; set;}
     string Section {get; set;}
    }
    
    class Teacher : IPerson
    {
     public Name {get; set;}
     public Salt {get; set;}
     public Section{get; set;}
     public Department{get; set;}
    }
    
    class Student : IPerson
    {
     public Name {get; set;}
     public Salt {get; set;}
     public Section{get; set;}
    }
    
    public string GetEncryptedName(IPerson person)
    {
     //return encrypted name based on Name and Salt property
     return encrypt(person.Salt,person.Name)
    }
