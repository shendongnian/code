    interface IPerson {
        string Name {get;set;}
        string Salt {get;set;}
    }
    
    class Teacher : IPerson...
    
    class Student : IPerson...
    
    public string GetEncryptedName(IPerson person)
    {
     //return encrypted name based on Name and Salt property
     return encrypt(person.Salt,person.Name)
    }
