    public class Person
    {
       public int ID {get;set;}
       public string Firstname {get;set;}
       public string Surname {get;set;}
       public string Lastname {get {return Surname;} set {Surname = value;}}
    }
